
namespace RailwayPhoneOfficeApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RailwayPhoneOfficeApp.Data.Models;
    using static RailwayPhoneOfficeApp.Common.Constants.EntityConstants.Employee;
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            // Define the primary key of the employee entity
            entity
                .HasKey(e => e.Id);

            // Define constraints for FullName column
            entity
                .Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(FullNameMaxLength);

            // Define constraints for Position column
            entity
                .Property(e => e.Position)
                .IsRequired()
                .HasMaxLength(PositionMaxLength);

            //// Define relation between the Employee and ApplicationUser entities
            //entity
            //    .HasOne(e => e.ApplicationUser)
            //    .WithOne(u => u.Employee)
            //    .HasForeignKey<Employee>(e => e.ApplicationUserId)
            //    .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
