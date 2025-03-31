
namespace RailwayPhoneOfficeApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RailwayPhoneOfficeApp.Data.Models;
    using static RailwayPhoneOfficeApp.Common.Constants.EntityConstants.Equipment;
    internal class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> entity)
        {
            // Define the primary key of the Equipment entity
            entity
                .HasKey(e => e.Id);

            // Define constraints for the Equipment Name column
            entity
                .Property(e => e.EquipmentName)
                .IsRequired()
                .HasMaxLength(EquipmentNameMaxLength);


        }
    }
}
