
namespace RailwayPhoneOfficeApp.Data.Models
{
    using Microsoft.EntityFrameworkCore;


    [Comment("Employee in the system")]
    public class Employee
    {
        [Comment("Employee identifier")]
        public Guid Id { get; set; }

        [Comment("Employee name")]
        public string FullName { get; set; } = null!;

        [Comment("Position of employee")]
        public string Position { get; set; } = null!;

        [Comment("Foreign key to the TelephoneExchange entity, workplace")]
        public Guid TelephoneExchangeId { get; set; }
        public virtual TelephoneExchange TelephoneExchange { get; set; } = null!;
       
        public virtual ICollection<EmployeeTask> Tasks { get; set; } = new HashSet<EmployeeTask>();

        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
