

namespace RailwayPhoneOfficeApp.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    [Comment("Action taken by the employee")]
    public class Action
    {
        [Comment("Action identifier")]
        public Guid Id { get; set; }

        [Comment("Type of action")]
        public string ActionType { get; set; } = null!;
  
    }
}
