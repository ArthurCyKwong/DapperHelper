using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DapperHelper.Console.model
{
    [Table("LAB_ATTENDANCE")]
    public class LabAttendanceModel : DatabaseModelBase
    {
        public LabAttendanceModel()
        {
        }

        public LabAttendanceModel(string id) : base(id)
        {
        }

        [Column("EMPLOYEE_ID", TypeName = "VARCHAR2")] public string EmployeeId { get; set; }
        [Column("WORK_DATE", TypeName = "DATE")] public DateTime WorkDate { get; set; }
        [Column("TIME_IN", TypeName = "TIMESTAMP")] public DateTime? TimeIn { get; set; }
        [Column("TIME_OUT", TypeName = "TIMESTAMP")] public DateTime? TimeOut { get; set; }

        [Column("LEAVE_APPLIED", TypeName = "VARCHAR2")] public string? LeaveApplied { get; set; }
        [Column("REMARKS", TypeName = "VARCHAR2")] public string? Remarks { get; set; }
        [Column("COMMENTS", TypeName = "VARCHAR2")] public string? Comments { get; set; }
        [Column("APPROVAL_STATUS", TypeName = "VARCHAR2")] public string? ApprovalStatus { get; set; }
        [Column("APPROVAL_DATE", TypeName = "TIMESTAMP")] public DateTime? ApprovalDate { get; set; }
        [Column("EXP_START_TIME", TypeName = "TIMESTAMP")] public DateTime? ExpectedStartTime { get; set; }
        [Column("EXP_END_TIME", TypeName = "TIMESTAMP")] public DateTime? ExpectedEndTime { get; set; }
        [Column("EXP_COMMENTS", TypeName = "VARCHAR2")] public string? ExpectedComment { get; set; }

        [NotMapped] public List<LabAllocationModel> Allocations { get; set; }
        [NotMapped] public List<LabAllowanceModel> Allowances { get; set; }
        [NotMapped] public List<LabInOutTimeModel> InOutTimes { get; set; }
    }
}
