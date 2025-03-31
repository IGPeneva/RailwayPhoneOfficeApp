
namespace RailwayPhoneOfficeApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using RailwayPhoneOfficeApp.Data.Models;
    using static RailwayPhoneOfficeApp.Common.Constants.EntityConstants.TelephoneExchange;

    internal class TelephoneExchangeConfiguration : IEntityTypeConfiguration<TelephoneExchange>
    {
        public void Configure(EntityTypeBuilder<TelephoneExchange> entity)
        {
            // Define the primary key of the Telephone Exchange entity
            entity
                .HasKey(te => te.Id);

            // Define constraints for Telephone Exchange Name column
            entity
                .Property(te => te.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            // Define constraints for Capacity column
            entity
                .Property(te => te.Capacity)
                .IsRequired()
                .HasMaxLength(MaxCapacity);


        }
    }
}
