

namespace RailwayPhoneOfficeApp.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    [Comment("Tasks for employees")]
    public class EmployeeTask
    {
        [Comment("Foreign key to the employee")]
        public Guid EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;

        [Comment("Foreign key to the task")]
        public Guid TaskId { get; set; }

        public virtual Task Task { get; set; } = null!;

    }
}
