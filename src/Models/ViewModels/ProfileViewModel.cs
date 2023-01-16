using System.ComponentModel.DataAnnotations;

namespace BugtrackerHF.Models.ViewModels;

public class ProfileViewModel
{
    [Required]
    public string? UserNickname { get; set; }
    [Required]
    public string? UserPicture { get; set; }
    [Required]
    [EmailAddress]
    public string? UserEmail { get; set; }
}