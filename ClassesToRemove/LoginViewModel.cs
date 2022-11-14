﻿using System.ComponentModel.DataAnnotations;

namespace BugtrackerHF.ClassesToRemove
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

    }
}