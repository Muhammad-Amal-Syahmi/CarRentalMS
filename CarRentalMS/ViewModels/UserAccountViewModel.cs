using System.ComponentModel.DataAnnotations;

namespace CarRentalMS.ViewModels
{
    public class UserAccountViewModel
    {
        public long UserID { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
        public int UserRoleID { get; set; }

    }
}