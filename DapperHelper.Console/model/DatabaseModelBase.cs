using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DapperHelper.Console.model
{
    public abstract class DatabaseModelBase
    {
        public DatabaseModelBase()
        {
            Id = Guid.NewGuid().ToString("N");
        }
        public DatabaseModelBase(string id)
        {
            Id = id;
        }

        [Column("ID", TypeName = "VARCHAR2")] public string Id { get; private set; }
        [Column("CREATED_BY", TypeName = "VARCHAR2")] public string CreatedBy { get; set; }
        [Column("CREATED_DT", TypeName = "TIMESTAMP")] public DateTime CreatedDate { get; set; }
        [Column("MODIFIED_BY", TypeName = "VARCHAR2")] public string ModifiedBy { get; set; }
        [Column("MODIFIED_DT", TypeName = "TIMESTAMP")] public DateTime ModifiedDate { get; set; }
    }
}
