using System;
using System.Configuration.Internal;
using System.Data;
using DapperHelper.Console.model;
using DapperHelper.Oracle;

namespace DapperHelper.Console.Database
{
    public class FromDatabase : DapperOracleDatabaseBase
    {
        protected override string connectionString => "";

        protected override string defaultSchema => "ABC";

        public override Type[] DatabaseTable()
        {          
            return new Type[] { 
                typeof(LabAttendanceModel),
                typeof(LabAllocationModel),
                typeof(LabInOutTimeModel),
                typeof(LabAllowanceModel)
            };
        }
    }
}
