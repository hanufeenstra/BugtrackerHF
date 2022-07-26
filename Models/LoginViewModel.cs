using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace BugtrackerHF.Models
{

    public class LoginViewModel
    {
        public string? Hashed { get; private set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress]
        public string? Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool Remember { get; set; }

        public void VerifyHash(RegisterViewModel registerViewModel)
        {
            Hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: Password,
                salt: registerViewModel.Salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
    }
}