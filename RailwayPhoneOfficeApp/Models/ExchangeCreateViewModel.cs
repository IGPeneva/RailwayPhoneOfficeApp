using System.ComponentModel.DataAnnotations;

namespace RailwayPhoneOfficeApp.Models
{
    public class ExchangeCreateViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Telephone exchange name is required.")]
        [StringLength(22,ErrorMessage ="Exchange name is too long.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Exchange capacity is required.")]
        [Range(1,500,ErrorMessage = "Out of range.")]
        public int Capacity { get; set; }
    }
}
