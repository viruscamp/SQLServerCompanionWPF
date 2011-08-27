using System.Collections.Generic;
using DataVirtualisation;
using Microsoft.SqlServer.Management.Smo;
using System.Data;

namespace SQLServerCompanion.HelperClasses
{
    public class VirtualizingSQLDataItemProvider : IItemsProvider<object,object,object>
    {

        private int count = -1;

        public VirtualizingSQLDataItemProvider()
        {
        }

        #region IItemsProvider

        public int FetchCount(object filter)
        {
            Table dbTable = filter as Table;

            if (dbTable.RowCount > 1000)
            {
                count = 1000;
            }
            else
            {
                count = (int)dbTable.RowCount;
            }

            return count;
        }

        public IList<object> FetchRange(object filter, object sorter,
            int startIndex, int pageCount, out int overallCount)
        {
            overallCount = count;
            string sqlScript = filter as string;

            Database SelectedDB = sorter as Database;

            DataSet ds = new DataSet();

            ds = SelectedDB.ExecuteWithResults(sqlScript);

            //var results = ds.Tables[0].Select().Skip(startIndex).Take(50).ToList<object>();
            var results = (ds as IList<object>);

            return results;
        }

        #endregion

    }//class
}//namespace
