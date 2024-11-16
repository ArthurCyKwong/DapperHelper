using System;
using System.Data;
using DapperHelper.Database;
using DapperHelper.Helper;
using Oracle.ManagedDataAccess.Client;

namespace DapperHelper.Oracle
{
    public abstract class DapperOracleDatabaseBase : DapperDatabaseBase
    {
        protected override IDapperSqlGeneration DapperSqlGenerator => new DapperOracleSqlGenerationExtension();
        public override IDbConnection GetConnection()
        {
            IDbConnection connection = new OracleConnection(connectionString);
            connection.Open();            
            return connection;
        }
    }
}
