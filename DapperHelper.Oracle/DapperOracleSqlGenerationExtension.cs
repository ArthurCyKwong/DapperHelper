using System.Reflection;
using System.ComponentModel.DataAnnotations.Schema;
using DapperHelper.Model;
using DapperHelper.Helper;
using System;
using System.Linq;

namespace DapperHelper.Oracle
{
    public class DapperOracleSqlGenerationExtension : IDapperSqlGeneration
    {
        #region GetTableName
        public string GetTableName<T>(string DefaultSchema = "")
        {
            return GetTableName(typeof(T), DefaultSchema);
        }

        public string GetTableName(Type type, string DefaultSchema = "")
        {
            var TableAttribute = type.GetCustomAttribute<TableAttribute>();
            var schema = string.IsNullOrEmpty(TableAttribute?.Schema?.Trim()) ? DefaultSchema : TableAttribute.Schema;
            var TableName = TableAttribute?.Name ?? type.Name;
            return string.Join(".", new string[] { schema, TableName }.Where(x => !string.IsNullOrEmpty(x)));
        }
        #endregion GetTableName

        #region GetTableFields
        public TableFieldModel[] GetTableFields<T>()
        {
            return GetTableFields(typeof(T));
        }
        public TableFieldModel[] GetTableFields(Type type)
        {
            var properties = type.GetProperties().Where(x => x.GetCustomAttribute<ColumnAttribute>() != null);
            return properties.Select(p => new TableFieldModel()
            {
                FieldName = p.Name,
                FieldDbName = p.GetCustomAttribute<ColumnAttribute>()?.Name ?? p.Name
            }).ToArray();
        }
        #endregion GetTableFields

        #region GenerateInsertSql
        public string GenerateInsertSql<T>(string DefaultSchema = "")
        {
            return GenerateInsertSql(typeof(T), DefaultSchema);
        }

        public string GenerateInsertSql(Type type, string DefaultSchema = "")
        {
            var tableName = GetTableName(type, DefaultSchema);
            var fields = GetTableFields(type);
            return GenerateInsertSql(tableName, fields);
        }

        public string GenerateInsertSql(TableGenerateSqlClass tableGenerateClass)
        {
            return GenerateInsertSql(tableGenerateClass.TableName, tableGenerateClass.Fields);
        }
        private string GenerateInsertSql(string tableName, TableFieldModel[] fields)
        {
            var columns = string.Join(",", fields.Select(p => p.FieldDbName));
            var values = string.Join(",", fields.Select(p => $":{p.FieldName}"));
            return $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
        }
        #endregion GenerateInsertSql

        #region GenerateSelectSql
        public string GenerateSelectSql<T>(string DefaultSchema = "")
        {
            return GenerateSelectSql(typeof(T), DefaultSchema);
        }

        public string GenerateSelectSql(Type type, string DefaultSchema = "")
        {
            var tableName = GetTableName(type, DefaultSchema);
            var fields = GetTableFields(type);
            return GenerateInsertSql(tableName, fields);
        }
        public string GenerateSelectSql(TableGenerateSqlClass tableGenerateClass)
        {
            return GenerateSelectSql(tableGenerateClass.TableName, tableGenerateClass.Fields);
        }
        private string GenerateSelectSql(string tableName, TableFieldModel[] fields)
        {
            var columns = string.Join(",", fields.Select(p => $"{p.FieldDbName} {p.FieldName}"));
            return $"SELECT {columns} FROM {tableName}";
        }
        #endregion GenerateSelectSql

        #region GenerateUpdateSql
        public string GenerateUpdateSql<T>(string DefaultSchema = "")
        {
            return GenerateUpdateSql(typeof(T), DefaultSchema);
        }

        public string GenerateUpdateSql(Type type, string DefaultSchema = "")
        {
            var tableName = GetTableName(type, DefaultSchema);
            var fields = GetTableFields(type);
            return GenerateUpdateSql(tableName, fields);
        }
        public string GenerateUpdateSql(TableGenerateSqlClass tableGenerateClass)
        {
            return GenerateUpdateSql(tableGenerateClass.TableName, tableGenerateClass.Fields);
        }
        private string GenerateUpdateSql(string tableName, TableFieldModel[] fields)
        {
            var columns = string.Join(",", fields.Select(p => $"{p.FieldDbName} = :{p.FieldName}"));
            return $"UPDATE {tableName} SET {columns}";
        }
        #endregion GenerateUpdateSql

        #region GenerateDeleteSql
        public string GenerateDeleteSql<T>(string DefaultSchema = "")
        {
            return GenerateDeleteSql(typeof(T), DefaultSchema);
        }

        public string GenerateDeleteSql(Type type, string DefaultSchema = "")
        {
            var tableName = GetTableName(type, DefaultSchema);
            return GenerateDeleteSql(tableName);
        }

        public string GenerateDeleteSql(TableGenerateSqlClass tableGenerateClass)
        {
            return GenerateDeleteSql(tableGenerateClass.TableName);
        }

        private string GenerateDeleteSql(string tableName)
        {
            return $"DELETE FROM {tableName}";
        }
        #endregion GenerateDeleteSql
    }
}
