namespace BugtrackerHF.Models;

public class AdminViewModel : UserViewModel
{
    public List<AdminViewModel>? Admins { get; set; }
    public List<UserViewModel>? Users { get; set; }
}