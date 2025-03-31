using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RailwayPhoneOfficeApp.Data.Models;
using Action = RailwayPhoneOfficeApp.Data.Models.Action;
using Task = RailwayPhoneOfficeApp.Data.Models.Task;

namespace RailwayPhoneOfficeApp.Data;

public class RailwayPhoneOfficeDbContext : IdentityDbContext<ApplicationUser,IdentityRole<Guid>, Guid>
{
    public RailwayPhoneOfficeDbContext()
    {
        
    }
    public RailwayPhoneOfficeDbContext(DbContextOptions<RailwayPhoneOfficeDbContext> options)
        : base(options)
    {

    }

    public virtual DbSet<TelephoneExchange> TelephoneExchanges { get; set; } = null!;
    public virtual DbSet<Task> Tasks { get; set; } = null!;
    public virtual DbSet<Employee> Employees { get; set; } = null!;
    public virtual DbSet<Replacement> Replacements { get; set; } = null!;
    public virtual DbSet<Equipment> Equipments { get; set; } = null!;
    public virtual DbSet<EmployeeTask> EmployeesTasks { get; set; } = null!;
    public virtual DbSet<Action> Actions { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}