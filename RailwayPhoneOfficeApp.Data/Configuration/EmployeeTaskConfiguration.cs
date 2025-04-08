
namespace RailwayPhoneOfficeApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RailwayPhoneOfficeApp.Data.Models;
    internal class EmployeeTaskConfiguration : IEntityTypeConfiguration<EmployeeTask>
    {
        public void Configure(EntityTypeBuilder<EmployeeTask> entity)
        {
            // Define constraints for EmployeeId column
            entity
                .Property(et => et.EmployeeId)
                .IsRequired();

            // Define constraints for TaskId column
            entity
                .Property(et => et.TaskId)
                .IsRequired();

            // Define composite key
            entity
                .HasKey(et => new { et.EmployeeId, et.TaskId });

            // Set default value of IsDeleted property
            entity
                .Property(et => et.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            // Define relation between the Employee and EmployeeTask entities
            entity
                .HasOne(et => et.Employee)
                .WithMany(e => e.Tasks)
                .HasForeignKey(et => et.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            // Define relation between the Task and EmployeeTask entities
            entity
                .HasOne(et => et.Task)
                .WithMany(t => t.Employees)
                .HasForeignKey(et => et.TaskId)
                .OnDelete(DeleteBehavior.NoAction);

            // Ensure that only existing records are used in the business logic
            entity
                .HasQueryFilter(et => et.IsDeleted == false);
        }
    }
}
