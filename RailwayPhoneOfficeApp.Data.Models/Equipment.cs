
namespace RailwayPhoneOfficeApp.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    [Comment("Equipment in the system")]
    public class Equipment
    {
        [Comment("Equipment identifier")]
        public Guid Id { get; set; }

        [Comment("Equipment name")]
        public string EquipmentName { get; set; } = null!;

        [Comment("Additional information/schema")]
        public string? Description { get; set; }

        [Comment("Foreign key to the TelephoneExchange entity")]
        public Guid TelephoneExchangeId { get; set; }
        public virtual TelephoneExchange TelephoneExchange { get; set; } = null!;

        public virtual ICollection<Task> Tasks { get; set; } = new HashSet<Task>();

    }
}
