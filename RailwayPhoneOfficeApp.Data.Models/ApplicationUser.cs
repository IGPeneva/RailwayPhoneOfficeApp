
namespace RailwayPhoneOfficeApp.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Net.Sockets;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
        }

        

       

        public bool IsAdmin { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsCustomer { get; set; }


        public List<Task> Tasks { get; set; }
    }
}
