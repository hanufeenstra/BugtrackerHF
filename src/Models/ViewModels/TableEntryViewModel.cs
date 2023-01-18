namespace BugtrackerHF.Models.ViewModels;

public class TableEntryViewModel
{
    public int RouteValue { get; set; }
    public Status CurrentStatus { get; set; }
    public string CreatorPicture { get; set; }
    public DateTime CreatedDate { get; set; }
    public string ProjectName { get; set; }
    public DateTime LastModified { get; set; }
    public Severity CurrentSeverity { get; set; }
}