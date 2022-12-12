using System.ComponentModel.DataAnnotations;
using System.Drawing.Text;
using BugtrackerHF.Models;

namespace BugtrackerHF.Models;

public enum Role
{
    ProjectManager = 0,     // Has Admin Rights
    TeamLeader = 1,         // Has Admin Rights
    Developer = 2           // Has User Rights
}


public class UserViewModel
{

    // default constructor to keep EF Core happy
    public UserViewModel() { }

    public int Id { get; set; }
    public string AuthZeroId { get; set; } = "";
    public string? UserNickname { get; set; }
    [EmailAddress]
    public string? UserEmail { get; set; }

    public string? UserPicture { get; set; }
    public Role UserRole { get; set; } = Role.Developer;
    public virtual ICollection<IssueViewModel>? IssueList { get; set; }

}
