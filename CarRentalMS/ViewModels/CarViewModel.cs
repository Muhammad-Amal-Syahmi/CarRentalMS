using System.ComponentModel.DataAnnotations;

namespace CarRentalMS.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Car Model")]
        [StringLength(120)]
        public string CarModel { get; set; }

        [Required]
        [StringLength(120)]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Price Per Day")]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^\d+(\.\d\d)?$", ErrorMessage = "It cannot have more than 2 decimal point value")]
        [Range(0.01, 999999999, ErrorMessage = "Price must be greater than 0.00")]
        public double? PricePerDay { get; set; }
    }
}