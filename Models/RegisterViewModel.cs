using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace BugtrackerHF.Models
{
    public class RegisterViewModel
    {
        public byte[]? Salt { get; private set; }

        public string? Hashed { get; private set; }

        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress]
        public string? Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        [RegularExpression(@"^([a-zA-Z0-9!@#$%^&*().?_]{8,15})$", ErrorMessage = "Password must contain: Minimum 8 characters at least 1 UpperCase Character, 1 LowerCase Character, 1 Number and 1 Special Character")]
        [NotMapped]
        public string? Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password Required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [NotMapped]
        public string? ConfirmPassword { get; set; }

        public void HashPassword()
        {
            Salt = new byte[128 / 8];

            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(Salt);
            }

            Hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: Password,
                salt: Salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
    }
}
