
namespace RailwayPhoneOfficeApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using RailwayPhoneOfficeApp.Data.Models;
    using static RailwayPhoneOfficeApp.Common.Constants.EntityConstants.Task;
    internal class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> entity)
        {
            // Define the primary key of the Task entity
            entity
                .HasKey(t => t.Id);

            // Define constraints for Task Description column
            entity
                .Property(t => t.TaskDescription)
                .IsRequired()
                .HasMaxLength(TaskDescriptionMaxLength);

            // Define constraints for the IsDamage column
            entity
                .Property(t => t.IsDamage)
                .IsRequired()
                .HasDefaultValue(false);

            // Define constraints for the StartDate column
            entity
                .Property(t => t.StartDate)
                .IsRequired();

            // Define constraints for the EndDate column
            entity
                .Property(t => t.EndDate)
                .IsRequired();

            entity
                .Property(t => t.Notes)
                .HasMaxLength(NotesMaxLength);

        }
    }
}
