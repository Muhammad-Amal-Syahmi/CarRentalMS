using System.ComponentModel.DataAnnotations;

namespace CarRentalMS.ViewModels
{
    public class CompanyViewModel
    {
        public int CompanyId { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Company Email")]
        public string CompanyEmail { get; set; }
    }
}