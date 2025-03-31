

namespace RailwayPhoneOfficeApp.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    [Comment("Phone Office in the system")]
    public class TelephoneExchange
    {
        [Comment("Telephone exchange identifier")]
        public Guid Id { get; set; }

        [Comment("Telephone exchange name")] 
        public string Name { get; set; } = null!;

        [Comment("Count of subscribers")]
        public int Capacity { get; set; }

        public virtual ICollection<Replacement> Replacements { get; set; } = new HashSet<Replacement>();

    }
}
