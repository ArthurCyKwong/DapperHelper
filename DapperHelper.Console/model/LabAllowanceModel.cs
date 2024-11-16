using System.ComponentModel.DataAnnotations.Schema;

namespace DapperHelper.Console.model;
[Table("LAB_ALLOWANCE")]
public class LabAllowanceModel : DatabaseModelBase
{
    public LabAllowanceModel()
    {
    }

    public LabAllowanceModel(string id) : base(id)
    {
    }

    [Column("ATTENDANCE_ID", TypeName = "VARCHAR2")] public string AttendanceId { get; set; }
    [Column("EMPLOYEE_ID", TypeName = "VARCHAR2")] public string EmployeeId { get; set; }
    [Column("WORK_DATE", TypeName = "DATE")] public DateTime WorkDate { get; set; }
    [Column("VERSION", TypeName = "NUMBER(10,0)")] public int Version { get; set; }
    [Column("CODE", TypeName = "VARCHAR2")] public string? Code { get; set; }
    [Column("UNIT", TypeName = "NUMBER(10,2)")] public decimal? Unit { get; set; }
    [Column("APPROVAL_STATUS", TypeName = "VARCHAR2")] public string? ApprovalStatus { get; set; }
    [Column("APPROVAL_DATE", TypeName = "TIMESTAMP")] public DateTime? ApprovalDate { get; set; }
    [NotMapped] public LabAttendanceModel Attendance { get; set; }
}