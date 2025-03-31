
namespace RailwayPhoneOfficeApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using RailwayPhoneOfficeApp.Data.Models;
    using Action = RailwayPhoneOfficeApp.Data.Models.Action;
    using static RailwayPhoneOfficeApp.Common.Constants.EntityConstants.Action;

    internal class ActionConfiguration : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> entity)
        {
            // Define the primary key of the Action entity
            entity
                .HasKey(a => a.Id);

            // Define constraints for ActionType column
            entity
                .Property(a => a.ActionType)
                .IsRequired()
                .HasMaxLength(ActionTypeMaxLength);

        }
    }
}
