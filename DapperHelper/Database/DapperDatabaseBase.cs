using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Xml.XPath;
using Dapper;
using DapperHelper.Helper;
using DapperHelper.Model;

namespace DapperHelper.Database
{
    public abstract class DapperDatabaseBase
    {
        protected abstract IDapperSqlGeneration DapperSqlGenerator { get; }
        protected abstract string connectionString { get; }
        protected abstract string defaultSchema { get; }
        private Dictionary<Type, TableGenerateSqlClass> _dbTableSqls = new Dictionary<Type, TableGenerateSqlClass>();
        public abstract IDbConnection GetConnection();
        public abstract Type[] DatabaseTable();

        public DapperDatabaseBase()
        {
            foreach (var type in DatabaseTable())
            {
                var tableSql = new TableGenerateSqlClass()
                {
                    TableName = DapperSqlGenerator.GetTableName(type, defaultSchema),
                    Fields = DapperSqlGenerator.GetTableFields(type),
                };
                tableSql.InsertSql = DapperSqlGenerator.GenerateInsertSql(tableSql);
                tableSql.UpdateAllSql = DapperSqlGenerator.GenerateUpdateSql(tableSql);
                tableSql.SelectAllSql = DapperSqlGenerator.GenerateSelectSql(tableSql);
                tableSql.DeleteSql = DapperSqlGenerator.GenerateDeleteSql(tableSql);
                _dbTableSqls.Add(type, tableSql);
            }
        }
        private TableGenerateSqlClass GetTable<T>(){
            if (!_dbTableSqls.TryGetValue(typeof(T), out var TableClass))
                throw new NotImplementedException("Table Not Found");
            return TableClass;
        }
        public string GetInsertSql<T>() => GetTable<T>().InsertSql;
        public string GetUpdateAllSql<T>() => GetTable<T>().UpdateAllSql;
        public string GetSelectAllSql<T>() => GetTable<T>().SelectAllSql;
        public string GetDeleteSql<T>() => GetTable<T>().DeleteSql;


        public int InsertData<T>(T[] data, IDbConnection conn, IDbTransaction transaction = null, int commendTimeOut = 30, CommandType commandType = CommandType.Text) =>
            conn.Execute(GetInsertSql<T>(), data, transaction,commendTimeOut, commandType);
    

        public T[] SelectAllData<T>(IDbConnection conn, IDbTransaction transaction = null, bool buffer = true, int commendTimeOut = 30, CommandType commandType = CommandType.Text) =>
            conn.Query<T>(GetSelectAllSql<T>(), null, transaction,buffer,commendTimeOut,commandType).ToArray();
    }
}
