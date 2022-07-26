namespace BugtrackerHF.Models;

public class ProjectViewModel
{
    public int Id { get; set; }
    public string? ProjectName { get; set; }
    public AdminViewModel? ProjectAdmin { get; set; }
    //public List<IssueViewModel>? IssueList { get; set; }
}