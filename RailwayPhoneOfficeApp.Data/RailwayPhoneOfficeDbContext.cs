using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RailwayPhoneOfficeApp.Data;

public class RailwayPhoneOfficeDbContext : IdentityDbContext
{
    public RailwayPhoneOfficeDbContext(DbContextOptions<RailwayPhoneOfficeDbContext> options)
        : base(options)
    {
    }
}