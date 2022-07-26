using System.ComponentModel.DataAnnotations;

namespace BugtrackerHF.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}