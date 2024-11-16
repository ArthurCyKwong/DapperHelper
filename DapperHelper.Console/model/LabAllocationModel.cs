using System.ComponentModel.DataAnnotations.Schema;

namespace DapperHelper.Console.model;
[Table("LAB_ALLOCATION")]
public class LabAllocationModel : DatabaseModelBase
{
    public LabAllocationModel()
    {
    }

    public LabAllocationModel(string id) : base(id)
    {
    }

    [Column("ATTENDANCE_ID", TypeName = "VARCHAR2")] public string AttendanceId { get; set; }
    [Column("EMPLOYEE_ID", TypeName = "VARCHAR2")] public string EmployeeId { get; set; }
    [Column("WORK_DATE", TypeName = "DATE")] public DateTime WorkDate { get; set; }
    [Column("VERSION", TypeName = "NUMBER(10,0)")] public int Version { get; set; }
    [Column("APPROVAL_STATUS", TypeName = "VARCHAR2")] public string? ApprovalStatus { get; set; }
    [Column("APPROVAL_DATE", TypeName = "TIMESTAMP")] public DateTime? ApprovalDate { get; set; }

    [Column("ALLOCATE_HOUR", TypeName = "NUMBER(10,2)")] public decimal? AllocationHour { get; set; }
    [Column("IS_OT", TypeName = "VARCHAR2")] public string? IsOT { get; set; }
    [Column("ACT_CODE", TypeName = "VARCHAR2")] public string? ActionCode { get; set; }
    [Column("SUBACT_CODE", TypeName = "VARCHAR2")] public string? SubActionCode { get; set; }
    [Column("LOC_CODE", TypeName = "VARCHAR2")] public string? LocationCode { get; set; }
    [Column("REFERENCE", TypeName = "VARCHAR2")] public string? Reference { get; set; }
    [Column("RESERVED_CODE", TypeName = "VARCHAR2")] public string? ReservedCode { get; set; }
    [Column("CONTRA_CHARGE", TypeName = "VARCHAR2")] public string? ContractCharge { get; set; }

    [Column("SUBCONTRACTOR_KEY", TypeName = "VARCHAR2")] public string? SubContractorKey { get; set; }
    [Column("CHARGING_BU", TypeName = "VARCHAR2")] public string? ChargingBu { get; set; }
    [Column("OBJECT_CODE", TypeName = "VARCHAR2")] public string? ObjectCode { get; set; }
    [Column("SUBSIDIARY", TypeName = "VARCHAR2")] public string? Subsidiary { get; set; }
    [Column("SUBLEDGER_TYPE", TypeName = "VARCHAR2")] public string? SubledgerType { get; set; }
    [Column("SUBLEDGER", TypeName = "VARCHAR2")] public string? Subledger { get; set; }
    [Column("CHARGING_DESCR", TypeName = "VARCHAR2")] public string? ChargingDescr { get; set; }
    [Column("SEQ", TypeName = "NUMBER")] public decimal Sequence { get; set; }

    [NotMapped] public LabAttendanceModel Attendance { get; set; }
}