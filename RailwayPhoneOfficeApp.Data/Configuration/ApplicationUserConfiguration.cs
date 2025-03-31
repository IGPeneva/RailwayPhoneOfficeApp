
namespace RailwayPhoneOfficeApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RailwayPhoneOfficeApp.Data.Models;

    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> entity)
        {
            // Define constraints for the IsEmployee column
            entity
                .Property(au => au.IsEmployee)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
