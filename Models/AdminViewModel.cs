namespace BugtrackerHF.Models;

public class AdminViewModel
{
    public int Id { get; set; }

    public string? AuthZeroId { get; set; }
    // Set ParentId to 0 if this is the top level admin 
    public int? ParentId { get; set; }
    public ICollection<UserViewModel>? Users { get; set; }
}