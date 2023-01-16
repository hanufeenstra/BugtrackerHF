using BugtrackerHF.Models;

namespace BugtrackerHF.Models;

public class ProjectModel
{
    public int Id { get; set; }
    public string? ProjectName { get; set; }
    public UserModel ProjectManager { get; set; }
    public IList<UserModel>? UserList { get; set; } = new List<UserModel>();
}