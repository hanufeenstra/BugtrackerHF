using System.ComponentModel.DataAnnotations;
using BugtrackerHF.Models;


namespace BugtrackerHF.Models.ViewModels;

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