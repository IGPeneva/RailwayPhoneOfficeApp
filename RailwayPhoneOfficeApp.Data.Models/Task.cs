


namespace RailwayPhoneOfficeApp.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    [Comment("Task in the system")]
    public class Task
    {
        [Comment("Task identifier")]
        public Guid Id { get; set; }

        [Comment("Task description")]
        public string TaskDescription { get; set; } = null!;

        [Comment("Failure pointer")]
        public bool IsDamage { get; set; }

        [Comment("Start of the task")]
        public DateTime StartDate { get; set; }

        [Comment("End of the task")]
        public DateTime EndDate { get; set; }

        [Comment("Notes for additional information")]
        public string? Notes { get; set; }

        [Comment("Foreign key to the Equipment entity")]
        public Guid EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; } = null!;

        [Comment("Foreign key to the Action entity")]
        public Guid ActionId { get; set; }
        public virtual Action Action { get; set; } = null!;

        public virtual ICollection<EmployeeTask> Employees { get; set; } = new HashSet<EmployeeTask>();
    }
}
