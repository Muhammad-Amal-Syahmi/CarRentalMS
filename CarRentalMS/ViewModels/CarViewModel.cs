using System;
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
        [Range(0.01, 999999999, ErrorMessage = "Price must be greater than 0.00")]
        public double? PricePerDay { get; set; }

        [Display(Name = "Date Modified")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MMM-dd HH:mm:ss}")]
        public DateTime? LastModifiedDate { get; set; }


    }
}