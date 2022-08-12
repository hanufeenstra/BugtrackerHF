using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BugtrackerHF.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "First Name")]
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^([a-zA-Z])$")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^([a-zA-Z])$")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        [RegularExpression(@"^([a-zA-Z0-9!@#$%^&*().?_]{8,15})$", ErrorMessage = "Password must contain: Minimum 8 characters at least 1 UpperCase Character, 1 LowerCase Character, 1 Number and 1 Special Character")]
        [NotMapped]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password Required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public string GetNickname()
        {
            return FirstName + " " + LastName;
        }

        
    }
}
