namespace DapperHelper.Model
{
    public class TableGenerateSqlClass
    {
        public string TableName{get;set;}
        public TableFieldModel[] Fields{get;set;}
        public string InsertSql{get;set;}
        public string UpdateAllSql{get;set;}
        public string SelectAllSql{get;set;}
        public string DeleteSql{get;set;}
    }


}
