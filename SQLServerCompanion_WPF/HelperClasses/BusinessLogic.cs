using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Reflection;
using System.Collections.Specialized;
using System.Data;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using System.IO;

namespace SQLServerCompanion.HelperClasses
{
    public class BusinessLogic
    {

        private Server _sqlServer;

        #region Constructor

        public BusinessLogic()
        {
            _sqlServer = DBServerConnectionSingleton.Instance.ActiveSQLServerConnection;
            ListOfDatabases = new List<Database>();
            ListOfTables = new List<Table>();
        }

        #endregion

        #region Methods

        public List<Database> GetDatabasesList()
        {
            var databases = from Database database in _sqlServer.Databases
                            select (database);

            ListOfDatabases.Clear();
            ListOfDatabases = databases.ToList();

            return ListOfDatabases;
        }

        public List<Table> GetTablesList(string selectedDB)
        {
            var tables = from Table table in _sqlServer.Databases[selectedDB].Tables
                         select (table);

            ListOfTables.Clear();
            ListOfTables = tables.ToList();

            return ListOfTables;
        }

        public List<object> GetDBObjectList(string selectedDB, enumDatabaseObjectTypes objectType)
        {
            List<object> retList = new List<object>();

            switch (objectType)
            {
                case enumDatabaseObjectTypes.Table:

                    var tables = from Table table in _sqlServer.Databases[selectedDB].Tables where table.IsSystemObject == false
                                 select (table);                    
                    retList = tables.ToList<object>();
                    break;

                case enumDatabaseObjectTypes.StoredProcedure:
                    var storedProcs = from StoredProcedure sp in _sqlServer.Databases[selectedDB].StoredProcedures where sp.IsSystemObject == false
                                 select (sp);
                    retList = storedProcs.ToList<object>();
                    break;

                case enumDatabaseObjectTypes.View:
                    var views = from View vw in _sqlServer.Databases[selectedDB].Views where vw.IsSystemObject == false
                                 select (vw);
                    retList = views.ToList<object>();
                    break;

                case enumDatabaseObjectTypes.Trigger:

                     List<Microsoft.SqlServer.Management.Smo.Trigger> trigList = new List<Microsoft.SqlServer.Management.Smo.Trigger>();

                    foreach (Table table in SelectedDB.Tables)
                    {
                        if (table.Triggers.Count > 0)
                        {
                            foreach (Microsoft.SqlServer.Management.Smo.Trigger trig in table.Triggers)
                            {
                                trigList.Add(trig);
                            }
                        }
                    }

                    retList = trigList.ToList<object>();

                    break;
                default :
                    break;
            }

            return retList;
        }

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            //e.Result = ScriptEverything();
            
            
        }

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {

                //MessageBox.Show(e.Error.Message);
                throw e.Error;
            }
            else
            {
                SQLScript = e.Result as string;

            }
            
        }

        public string ScriptEverything(Database selectedDB, ObjectsToScriptOptions objectsToScript)
        {
            Microsoft.SqlServer.Management.Smo.Table tbl = null;
            StringBuilder sb = new StringBuilder();

            objectsToScriptOptions = objectsToScript;

            SelectedDB = selectedDB;

            ClearVariables();

            Console.WriteLine("Scripting tables started at : " + DateTime.Now);

            Table[] tbls = new Table[SelectedDB.Tables.Count];
            SelectedDB.Tables.CopyTo(tbls, 0);

            DependencyTree tree = DBServerConnectionSingleton.Instance.DBScripter.DiscoverDependencies(tbls, true);
            DependencyWalker depwalker = new Microsoft.SqlServer.Management.Smo.DependencyWalker();
            DependencyCollection depcoll = depwalker.WalkDependencies(tree);

            ScriptSchemas();

            SQLScript += SQLScriptSchemas;

            sb.AppendLine("--================ Start of Table objects script ( " + DateTime.Now + " ) ================");
            sb.AppendLine(Environment.NewLine);

            foreach (DependencyCollectionNode dep in depcoll)
            {
                tbl = SelectedDB.Tables[dep.Urn.GetAttribute("Name"), dep.Urn.GetAttribute("Schema")];

                ScriptingOptions options = new ScriptingOptions();
                options.NoCollation = true;
                options.ClusteredIndexes = false;
                options.Default = true;
                options.DriAll = false;
                options.Indexes = false;
                options.IncludeHeaders = true;
                options.IncludeIfNotExists = true;
                options.SchemaQualify = true;
                options.DriDefaults = true;


                if (!tbl.IsSystemObject)
                {
                    if (objectsToScript.ScriptTables)
                    {
                        StringCollection coll = tbl.Script(options);
                        foreach (string str in coll)
                        {
                            sb.Append(str);
                            sb.Append(Environment.NewLine);
                        }
                        sb.AppendLine("GO");
                    }

                    Console.WriteLine(tbl.Name);

                    if (objectsToScript.ScriptIndexes)  ScriptIndexes(tbl);
                    if (objectsToScript.ScriptForeignKeys)  ScriptForeignKeys(tbl);
                    if (objectsToScript.ScriptTriggers)  ScriptTriggers(tbl);
                    
                }
            }

            sb.AppendLine("--================ End of Table objects script ( " + DateTime.Now + " ) ================");
            sb.AppendLine(Environment.NewLine);

            Console.WriteLine("Scripting tables finished at : " + DateTime.Now);

            if (objectsToScript.ScriptUserDefinedFunctions)  ScriptUserDefinedFunctions(selectedDB);
            if (objectsToScript.ScriptStoredProcs) ScriptStoredProcs(selectedDB);
            if (objectsToScript.ScriptViews)  ScriptViews(selectedDB);

            SQLScript += sb.ToString();
            SQLScript += SQLScriptFunctions;

            return SQLScript;
        }

        private string ScriptSchemas()
        {
            StringBuilder sb = new StringBuilder();

            ScriptingOptions option = new ScriptingOptions();
            option.IncludeIfNotExists = true;
            option.IncludeHeaders = true;

            sb.AppendLine("--================ Start of Schemas script ( " + DateTime.Now + " ) ================");

            foreach (Schema schema in SelectedDB.Schemas)
            {
                if (!schema.IsSystemObject)
                {
                    StringCollection coll = schema.Script(option);
                    foreach (string str in coll)
                    {
                        sb.Append(str);
                        sb.Append(Environment.NewLine);
                    }
                    sb.AppendLine("GO");
                }
            }

            sb.AppendLine("--================ End of Schemas script ( " + DateTime.Now + " ) ================");
            sb.AppendLine(Environment.NewLine);

            SQLScriptSchemas = sb.ToString();
            return SQLScriptSchemas;
        }

        private void ScriptForeignKeys(Microsoft.SqlServer.Management.Smo.Table tableToScript)
        {
            if (tableToScript.ForeignKeys.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                StringBuilder resultScript = new StringBuilder(string.Empty);

                StringBuilder resultScriptToAddFK = new StringBuilder(string.Empty);

                foreach (ForeignKey fk in tableToScript.ForeignKeys)
                {
                     //Only insert data when table is empty
                    resultScript.AppendFormat("IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{0}].[{1}]') AND parent_object_id = OBJECT_ID(N'[{2}]'))", fk.ReferencedTableSchema, fk.Name, fk.Parent).Append(Environment.NewLine);
                    resultScript.AppendLine("BEGIN");
                    resultScript.AppendFormat("ALTER TABLE {0} DROP CONSTRAINT [{1}]", fk.Parent, fk.Name).Append(Environment.NewLine);
                    resultScript.AppendLine("END").Append(Environment.NewLine);

                    resultScriptToAddFK.AppendFormat("ALTER TABLE {0} WITH CHECK ADD CONSTRAINT [{1}] FOREIGN KEY([{2}]) REFERENCES [{3}].[{4}] ([{5}])", fk.Parent, fk.Name, fk.Columns[0].Name, fk.ReferencedTableSchema, fk.ReferencedTable, fk.Columns[0].ReferencedColumn).Append(Environment.NewLine);
                   

                }

                SQLScriptForeignKeysDrop += resultScript.ToString();

                SQLScriptForeignKeysAdd += resultScriptToAddFK.ToString();

            }
        }

        public string ScriptTableData(Microsoft.SqlServer.Management.Smo.Table tableToScript)
        {
            StringBuilder resultScript = new StringBuilder(string.Empty);			
            String targetFile = CurrentDirectoryPath + @"\DataScript_" + tableToScript.Name + ".sql";
            			
            //Always delete a previous file.
            if (File.Exists(targetFile)) File.Delete(targetFile);

            // Generate script
            // Include content in script
            // Exclude table schema (table creation etc.) and Dri (foreignkeys etc.)


            // Only insert data when table is empty
            resultScript.AppendFormat(LogToFile(targetFile,("IF NOT EXISTS (SELECT 1 FROM [dbo].[" + tableToScript.Name + "])" + Environment.NewLine)));
            resultScript.AppendLine(LogToFile(targetFile,"BEGIN"));

            Scripter scripter = new Scripter(_sqlServer);
            ScriptingOptions options = new ScriptingOptions();
            options.DriAll = false;
            options.ScriptSchema = false;
            options.ScriptData = true;
            scripter.Options = options;

            // Add script to file content
            foreach (string scriptLine in scripter.EnumScript(new Urn[] { tableToScript.Urn }))
            {
                string line = scriptLine;
                line = line.Replace("SET ANSI_NULLS ON", string.Empty);
                line = line.Replace("SET QUOTED_IDENTIFIER ON", string.Empty);
                line = line.Replace("SET ANSI_NULLS OFF", string.Empty);
                line = line.Replace("SET QUOTED_IDENTIFIER OFF", string.Empty);

                resultScript.AppendLine(line.Trim());

                LogToFile(targetFile, line);               
            }

            resultScript.AppendLine(LogToFile(targetFile, "END"));

            return resultScript.ToString();
        }

        private void ScriptIndexes(Microsoft.SqlServer.Management.Smo.Table tableToScript)
        {

            ScriptingOptions options = new ScriptingOptions();
            options.ScriptDrops = true;
            options.ScriptSchema = true;
            options.NoCollation = true;
            options.ClusteredIndexes = true;
            options.Default = true;
            options.NonClusteredIndexes = true;
            options.IncludeIfNotExists = true;
            options.Indexes = true;
            

            if (tableToScript.Indexes.Count > 0)
            {
                StringBuilder resultScript = new StringBuilder(string.Empty);

                StringCollection coll = null;
                
                foreach (Index ix in tableToScript.Indexes)
                {
                    coll = ix.Script();
                    
                    foreach (string str in coll)
                    {
                        resultScript.Append(str);
                        resultScript.Append(Environment.NewLine);
                    }
                }

                SQLScriptIndexes += resultScript;
                SQLScriptIndexes += Environment.NewLine;
            }

        }

        private void ScriptStoredProcs(Database selectedDB)
        {
            SQLScriptStoredProcs += ("--================ Start of Stored Procedure objects script ( " + DateTime.Now + " ) ================");
            SQLScriptStoredProcs += Environment.NewLine;

            Console.WriteLine("Scripting stored procs started at : " + DateTime.Now);
            
            ScriptingOptions options = new ScriptingOptions();
            string dropScript = "";

            StringBuilder resultScript = new StringBuilder(string.Empty);

            StringCollection coll = null;

            foreach (StoredProcedure sp in selectedDB.StoredProcedures)
            {
                if (!sp.IsSystemObject)
                {
                    options.ScriptDrops = true;
                    options.IncludeIfNotExists = true;
                    coll = sp.Script(options);

                    resultScript = new StringBuilder(string.Empty);

                    foreach (string str in coll)
                    {
                        resultScript.Append(str);
                        resultScript.Append(Environment.NewLine);
                    }

                    dropScript = resultScript.ToString();
                    dropScript += "GO";
                    dropScript += Environment.NewLine;
                    dropScript += Environment.NewLine;
                    Console.WriteLine(sp.Name);
                }

                if (!sp.IsSystemObject)
                {
                    resultScript = new StringBuilder(string.Empty);

                    coll = sp.Script();

                    foreach (string str in coll)
                    {
                        string tmpString = str;
                        tmpString = tmpString.Replace("SET ANSI_NULLS ON", string.Empty);
                        tmpString = tmpString.Replace("SET QUOTED_IDENTIFIER ON", string.Empty);
                        tmpString = tmpString.Replace("SET QUOTED_IDENTIFIER OFF", string.Empty);                        

                        resultScript.Append(tmpString);
                        resultScript.Append(Environment.NewLine);
                    }

                    SQLScriptStoredProcs += dropScript;
                    SQLScriptStoredProcs += resultScript.ToString();
                    SQLScriptStoredProcs += "GO";
                    SQLScriptStoredProcs += Environment.NewLine;
                    SQLScriptStoredProcs += Environment.NewLine;
                }
                
            }

            SQLScriptStoredProcs += ("--================ End of Stored Procedure objects script ( " + DateTime.Now + " ) ================");
            SQLScriptStoredProcs += Environment.NewLine;


            Console.WriteLine("Scripting stored procs ended at : " + DateTime.Now);
       
        }

        private void ScriptViews(Database selectedDB)
        {
            SQLScriptViews += ("--================ Start of View objects script ( " + DateTime.Now + " ) ================");
            SQLScriptViews += Environment.NewLine;

            Console.WriteLine("Scripting views procs started at : " + DateTime.Now);

            ScriptingOptions options = new ScriptingOptions();
            string dropScript = "";

            StringBuilder resultScript = new StringBuilder(string.Empty);

            StringCollection coll = null;

            foreach (View vw in selectedDB.Views)
            {
                if (!vw.IsSystemObject)
                {
                    options.ScriptDrops = true;
                    options.IncludeIfNotExists = true;
                    coll = vw.Script(options);

                    resultScript = new StringBuilder(string.Empty);

                    foreach (string str in coll)
                    {
                        resultScript.Append(str);
                        resultScript.Append(Environment.NewLine);
                    }

                    dropScript = resultScript.ToString();
                    dropScript += "GO";
                    dropScript += Environment.NewLine;
                    dropScript += Environment.NewLine;
                    Console.WriteLine(vw.Name);
                }

                if (!vw.IsSystemObject)
                {
                    resultScript = new StringBuilder(string.Empty);

                    coll = vw.Script();

                    foreach (string str in coll)
                    {
                        string tmpString = str;
                        tmpString = tmpString.Replace("SET ANSI_NULLS ON", string.Empty);
                        tmpString = tmpString.Replace("SET QUOTED_IDENTIFIER ON", string.Empty);

                        resultScript.Append(tmpString);
                        resultScript.Append(Environment.NewLine);
                    }

                    SQLScriptViews += dropScript;
                    SQLScriptViews += resultScript.ToString();
                    SQLScriptViews += "GO";
                    SQLScriptViews += Environment.NewLine;
                    SQLScriptViews += Environment.NewLine;
                }
            }

            SQLScriptViews += ("--================ End of View objects script ( " + DateTime.Now + " ) ================");
            SQLScriptViews += Environment.NewLine;

            Console.WriteLine("Scripting stored views ended at : " + DateTime.Now);

        }

        private void ScriptUserDefinedFunctions(Database selectedDB)
        {
            SQLScriptStoredProcs += ("--================ Start of User Defined Functions objects script ( " + DateTime.Now + " ) ================");
            SQLScriptStoredProcs += Environment.NewLine;

            Console.WriteLine("Scripting User Defined Functions started at : " + DateTime.Now);

            ScriptingOptions options = new ScriptingOptions();
            options.IncludeIfNotExists = true;
            options.IncludeHeaders = true;

            StringBuilder resultScript = new StringBuilder(string.Empty);

            StringCollection coll = null;

            foreach (UserDefinedFunction fc in selectedDB.UserDefinedFunctions)
            {
                if (!fc.IsSystemObject)
                {
                    coll = fc.Script(options);

                    resultScript = new StringBuilder(string.Empty);

                    foreach (string str in coll)
                    {
                        resultScript.Append(str);
                        resultScript.Append(Environment.NewLine);
                    }

                    SQLScriptFunctions = resultScript.ToString();
                    SQLScriptFunctions += "GO";
                    SQLScriptFunctions += Environment.NewLine;
                    Console.WriteLine(fc.Name);
                }
            }
        }

        private void ScriptTriggers(Microsoft.SqlServer.Management.Smo.Table tableToScript)
        {
            ScriptingOptions options;

            Console.WriteLine("Scripting Trigger objects started at : " + DateTime.Now);

            StringBuilder resultScript = new StringBuilder(string.Empty);

            StringCollection coll = null;

            foreach (Microsoft.SqlServer.Management.Smo.Trigger trg in tableToScript.Triggers)
            {

                if (!trg.IsSystemObject)
                {
                    //Script drop
                    options = new ScriptingOptions();
                    options.IncludeIfNotExists = true;
                    options.ScriptDrops = true;
                    options.IncludeHeaders = true;

                    coll = trg.Script(options);

                    resultScript = new StringBuilder(string.Empty);

                    foreach (string str in coll)
                    {
                        resultScript.Append(str);
                        resultScript.Append(Environment.NewLine);
                    }

                    SQLScriptTriggers = resultScript.ToString();
                    SQLScriptTriggers += "GO";
                    SQLScriptTriggers += Environment.NewLine;
                    SQLScriptTriggers += Environment.NewLine;

                    //Script Create
                    options = new ScriptingOptions();
                    options.IncludeIfNotExists = true;
                    options.IncludeHeaders = true;

                    coll = trg.Script(options);

                    resultScript = new StringBuilder(string.Empty);

                    foreach (string str in coll)
                    {
                        resultScript.Append(str);
                        resultScript.Append(Environment.NewLine);
                    }

                    SQLScriptTriggers += resultScript.ToString();
                    SQLScriptTriggers += "GO";
                    SQLScriptTriggers += Environment.NewLine;
                    Console.WriteLine(trg.Name);
                }
            }
        }


        private void ClearVariables()
        {
            SQLScriptStoredProcs = "";
            SQLScriptIndexes = "";
            SQLScript = "";
            SQLScriptForeignKeysAdd = "";
            SQLScriptForeignKeysDrop = "";
            SQLScriptViews = "";
            SQLScriptSchemas = "";
            SQLScriptTriggers = "";
        }

        private void GetActiveConnections(string database)
        {
            DataTable allConnections = _sqlServer.EnumProcesses(true);

            DataView databaseConnections = new DataView(allConnections);
            databaseConnections.RowFilter = string.Format("Database = '{0}'", database);

            foreach (DataRowView rowView in databaseConnections)
                Console.WriteLine("SPID <{0}> Database <{1}> Host<{2}> Program <{3}> User <{4}>",
                rowView["Spid"], rowView["Database"],
                rowView["Host"], rowView["Program"], rowView["Login"]);
        }

        public static string LogToFile(string targetFile, string textToWrite)
        {
            // Create a writer and open the file:
            StreamWriter scriptFile;

            if (!File.Exists(targetFile))
            {
                scriptFile = new StreamWriter(targetFile);
            }
            else
            {
                scriptFile = File.AppendText(targetFile);
            }

            // write a line of text to the file
            scriptFile.WriteLine(textToWrite);

            // close the stream
            scriptFile.Close();

            return textToWrite;
        }

        #endregion

        #region Public properties


        public ObjectsToScriptOptions objectsToScriptOptions;

        public string CurrentDirectoryPath
        {
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }
		
		public string GetLocalFileStoragePath
		{
			get { return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); }
		}

        private List<Database> ListOfDatabases { get; set; }
        private List<Table> ListOfTables { get; set; }

        private Database _SelectedDB;
        public Database SelectedDB
        {
            get { return _SelectedDB; }

            set
            {
                _SelectedDB = value;                
            }
        }

        private string _sqlScript;
        public string SQLScript
        {
            get { return _sqlScript; }
            set
            {
                _sqlScript = value;                
            }
        }

        private string _sqlScriptForeignKeysDrop = "-- ======= Script for dropping foreign key constraints =======" + Environment.NewLine;
        public string SQLScriptForeignKeysDrop
        {
            get { return _sqlScriptForeignKeysDrop; }
            set
            {
                _sqlScriptForeignKeysDrop = value;                
            }
        }

        private string _sqlScriptForeignKeysAdd = "-- ======= Script for adding foreign key constraints =======" + Environment.NewLine;
        public string SQLScriptForeignKeysAdd
        {
            get { return _sqlScriptForeignKeysAdd; }
            set
            {
                _sqlScriptForeignKeysAdd = value;                
            }
        }

        private string _sqlScriptStoredProcs = "";
        public string SQLScriptStoredProcs
        {
            get { return _sqlScriptStoredProcs; }
            set
            {
                _sqlScriptStoredProcs = value;                
            }
        }

        private string _sqlScriptViews = "";
        public string SQLScriptViews
        {
            get { return _sqlScriptViews; }
            set
            {
                _sqlScriptViews = value;                
            }
        }

        private string _sqlScriptIndexes = "";
        public string SQLScriptIndexes
        {
            get { return _sqlScriptIndexes; }
            set
            {
                _sqlScriptIndexes = value;
            }
        }

        private string _sqlScriptSchemas = "";
        public string SQLScriptSchemas
        {
            get { return _sqlScriptSchemas; }
            set
            {
                _sqlScriptSchemas = value;
            }
        }

        private string _sqlScriptTriggers = "";
        public string SQLScriptTriggers
        {
            get { return _sqlScriptTriggers; }
            set
            {
                _sqlScriptTriggers = value;
            }
        }

        private string _sqlScriptFunctions = "";
        public string SQLScriptFunctions
        {
            get { return _sqlScriptFunctions; }
            set
            {
                _sqlScriptFunctions = value;
            }
        }

        #endregion

    }//class Business Logic


    /// <summary>
    /// Class used to define what objects to script
    /// </summary>
    public class ObjectsToScriptOptions
    {

        //Constructor
        public ObjectsToScriptOptions(bool scriptTables, bool scriptStoredProcs, bool scriptForeignKeys, bool scriptIndexes, bool scriptTriggers, bool scriptUserDefinedFunctions, bool scriptViews)
        {
            this.ScriptTables = scriptTables;
            this.ScriptStoredProcs = scriptStoredProcs;
            this.ScriptForeignKeys = scriptForeignKeys;
            this.ScriptIndexes = scriptIndexes;
            this.ScriptTriggers = scriptTriggers;
            this.ScriptUserDefinedFunctions = scriptUserDefinedFunctions;
            this.ScriptViews = scriptViews;
        }

        #region Properties

        private bool _scriptTables = false;
        public bool ScriptTables
        {
            get { return _scriptTables; }
            private set { _scriptTables = value; }
        }

        private bool _scriptStoredProcs = false;
        public bool ScriptStoredProcs
        {
            get { return _scriptStoredProcs; }
            private set { _scriptStoredProcs = value; }
        }

        private bool _scriptForeignKeys = false;
        public bool ScriptForeignKeys
        {
            get { return _scriptForeignKeys; }
            private set { _scriptForeignKeys = value; }
        }

        private bool _scriptTriggers = false;
        public bool ScriptTriggers
        {
            get { return _scriptTriggers; }
            private set { _scriptTriggers = value; }
        }

        private bool _scriptIndexes = false;
        public bool ScriptIndexes
        {
            get { return _scriptIndexes; }
            private set { _scriptIndexes = value; }
        }

        private bool _scriptUserDefinedFunctions = false;
        public bool ScriptUserDefinedFunctions
        {
            get { return _scriptUserDefinedFunctions; }
            private set { _scriptUserDefinedFunctions = value; }
        }

        private bool _scriptUserViews = false;
        public bool ScriptViews
        {
            get { return _scriptUserViews; }
            private set { _scriptUserViews = value; }
        }

        #endregion
    }
}
