using System.ComponentModel.DataAnnotations;
using System.Drawing.Text;
using BugtrackerHF.Models;

namespace BugtrackerHF.Models;

public class UserModel
{
    public int Id { get; set; }
    public string AuthZeroId { get; set; } = "";
    public string? UserNickname { get; set; }
    [EmailAddress]
    public string? UserEmail { get; set; }
    public string? UserPicture { get; set; }
    public Role UserRole { get; set; } = Role.User;
    public virtual IList<IssueModel>? IssueList { get; set; } = new List<IssueModel>();
    public virtual IList<UserModel>? SubUserList { get; set; } = new List<UserModel>();
}
