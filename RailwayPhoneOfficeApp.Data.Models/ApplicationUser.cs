
namespace RailwayPhoneOfficeApp.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
        }

        public bool IsEmployee { get; set; }

        public virtual Employee Employee { get; set; }

    }
}
