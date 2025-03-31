
namespace RailwayPhoneOfficeApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RailwayPhoneOfficeApp.Data.Models;
    using static RailwayPhoneOfficeApp.Common.Constants.EntityConstants.Replacement;
    internal class ReplacementConfiguration : IEntityTypeConfiguration<Replacement>
    {
        public void Configure(EntityTypeBuilder<Replacement> entity)
        {
            // Define the primary key of the Replacement entity
            entity
                .HasKey(r => r.Id);

            // Define constraints for Replacement Name column
            entity
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(ReplacementNameMaxLength);

            // Define constraints for the Status column
            entity
                .Property(r => r.Status)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
