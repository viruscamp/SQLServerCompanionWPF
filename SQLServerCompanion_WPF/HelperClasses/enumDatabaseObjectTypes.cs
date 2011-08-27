using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLServerCompanion.HelperClasses
{
    public enum enumDatabaseObjectTypes : int
    {
        Database,
        Table,
        StoredProcedure,
        Trigger,
        View,
        UDF,
        ForeignKey,
        Indexes,
        Everything        
    }
}
