using System.ComponentModel.DataAnnotations;

namespace CarRentalMS.ViewModels
{
    public class UserAccountViewModel
    {
        public long UserID { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
        public int UserRoleID { get; set; }

    }
}