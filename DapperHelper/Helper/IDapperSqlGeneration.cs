using System;
using DapperHelper.Model;

namespace DapperHelper.Helper
{
    public interface IDapperSqlGeneration
    {
        string GetTableName<T>(string DefaultSchema = "");
        string GetTableName(Type type, string DefaultSchema = "");
        TableFieldModel[] GetTableFields<T>();
        TableFieldModel[] GetTableFields(Type type);
        string GenerateInsertSql<T>(string DefaultSchema = "");
        string GenerateInsertSql(Type type, string DefaultSchema = "");
        string GenerateInsertSql(TableGenerateSqlClass tableGenerateClass);
        string GenerateUpdateSql<T>(string DefaultSchema = "");
        string GenerateUpdateSql(Type type, string DefaultSchema = "");
        string GenerateUpdateSql(TableGenerateSqlClass tableGenerateClass);
        string GenerateSelectSql<T>(string DefaultSchema = "");
        string GenerateSelectSql(Type type, string DefaultSchema = "");
        string GenerateSelectSql(TableGenerateSqlClass tableGenerateClass);
        string GenerateDeleteSql<T>(string DefaultSchema = "");
        string GenerateDeleteSql(Type type, string DefaultSchema = "");
        string GenerateDeleteSql(TableGenerateSqlClass tableGenerateClass);

    }
}
