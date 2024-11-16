using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DapperHelper.Console.model
{
    [Table("LAB_INOUTTIME")]
    public class LabInOutTimeModel : DatabaseModelBase
    {
        public LabInOutTimeModel()
        {
        }

        public LabInOutTimeModel(string id) : base(id)
        {
        }

        [Column("ATTENDANCE_ID", TypeName = "VARCHAR2")] public string AttendanceId { get; set; }
        [Column("EMPLOYEE_ID", TypeName = "VARCHAR2")] public string EmployeeId { get; set; }
        [Column("WORK_DATE", TypeName = "DATE")] public DateTime WorkDate { get; set; }
        [Column("VERSION", TypeName = "NUMBER(10,0)")] public int Version { get; set; }
        [Column("START_TIME", TypeName = "TIMESTAMP")] public DateTime? StartTime { get; set; }
        [Column("END_TIME", TypeName = "TIMESTAMP")] public DateTime? EndTime { get; set; }
        [Column("MB_HOUR", TypeName = "NUMBER(10,2)")] public decimal? MealBreakHour { get; set; }
        [Column("TOTAL_HOUR", TypeName = "NUMBER(10,2)")] public decimal? TotalHour { get; set; }
        [Column("NORMAL_HOUR", TypeName = "NUMBER(10,2)")] public decimal? NormalHour { get; set; }
        [Column("OT_HOUR", TypeName = "NUMBER(10,2)")] public decimal? OTHour { get; set; }
        [Column("NS_HOUR", TypeName = "NUMBER(10,2)")] public decimal? NightShiftHour { get; set; }
        [Column("SUN_HOUR", TypeName = "NUMBER(10,2)")] public decimal? SundayWorkHour { get; set; }
        [Column("APPROVAL_STATUS", TypeName = "VARCHAR2")] public string? ApprovalStatus { get; set; }
        [Column("APPROVAL_DATE", TypeName = "TIMESTAMP")] public DateTime? ApprovalDate { get; set; }

        [NotMapped] public LabAttendanceModel Attendance { get; set; }
    }
}
