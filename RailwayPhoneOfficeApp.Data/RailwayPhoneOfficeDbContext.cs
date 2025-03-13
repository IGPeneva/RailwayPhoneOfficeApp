using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RailwayPhoneOfficeApp.Data.Models;

namespace RailwayPhoneOfficeApp.Data;

public class RailwayPhoneOfficeDbContext : IdentityDbContext<ApplicationUser,IdentityRole<Guid>, Guid>
{
    public RailwayPhoneOfficeDbContext(DbContextOptions<RailwayPhoneOfficeDbContext> options)
        : base(options)
    {
    }
}