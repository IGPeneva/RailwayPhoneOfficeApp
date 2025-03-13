
using Microsoft.AspNetCore.Identity;

namespace RailwayPhoneOfficeApp.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
        }

    }
}
