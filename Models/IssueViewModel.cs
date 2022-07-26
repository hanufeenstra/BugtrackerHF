namespace BugtrackerHF.Models;

public class IssueViewModel
{
    public enum Severity
    {
        Critical = 4,
        Major = 3,
        Moderate = 2,
        Minor = 1,
        Cosmetic = 0
    }

    public enum Status
    {
        Unopened = 0,
        Assigned = 1,
        Pending = 2,
        InProgress = 3,
        Testing = 4,
        Resolved = 5
    }

    public IssueViewModel()
    {
        CommentList = new List<CommentViewModel>();
        CurrentStatus = 0;
    }

    public int Id { get; set; }
    public string? IssueName { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? LastUpdateDate { get; set; }
    public Severity CurrentSeverity { get; set; }
    public Status CurrentStatus { get; set; }
    public int ReportedByUserId { get; set; }
    public int AssignedToUserId { get; set; }
    public List<CommentViewModel>? CommentList { get; set; }

    public void IncreaseSeverity()
    {
        // Severity.Critical is largest enum value
        if (CurrentSeverity < Severity.Critical)
        {
             CurrentSeverity += 1;
        }
    }

    public void DecreaseSeverity()
    {
        // Severity.Cosmetic is smallest enum value
        if (CurrentSeverity > Severity.Cosmetic)
        {
            CurrentSeverity -= 1;
        }
    }

}

