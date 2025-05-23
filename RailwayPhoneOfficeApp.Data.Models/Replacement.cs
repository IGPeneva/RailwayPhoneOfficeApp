﻿
namespace RailwayPhoneOfficeApp.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    [Comment("Replacement part for equipment")]
    public class Replacement
    {

        [Comment("Replacement part identifier")]
        public Guid Id { get; set; }

        [Comment("Replacement part name")] 
        public string Name { get; set; } = null!;

        [Comment("Replacement part works or not")]
        public bool Status { get; set; }

        [Comment("Foreign key to the TelephoneExchange entity")]
        public Guid TelephoneExchangeId { get; set; }
        public virtual TelephoneExchange TelephoneExchange { get; set; }

    }
}
