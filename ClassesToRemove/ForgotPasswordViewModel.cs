using System.ComponentModel.DataAnnotations;

namespace BugtrackerHF.ClassesToRemove
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}