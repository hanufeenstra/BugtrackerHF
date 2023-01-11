using System.ComponentModel.DataAnnotations;

namespace BugtrackerHF.src.Models.ViewModels;

public class CreateIssueViewModel
{
    public IList<ProjectModel> ProjectList { get; set; }
    [Required]
    public ProjectModel SelectedProject { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }

}