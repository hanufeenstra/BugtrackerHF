using System.ComponentModel.DataAnnotations.Schema;

namespace BugtrackerHF.Models;

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
    Resolved = 5,
    Rejected = 6
}



public class IssueViewModel
{

    // Default Constructor
    public IssueViewModel()
    {
    }

    // Constructor for DI
    public IssueViewModel(
        IList<MessageViewModel> commentList, 
        MessageViewModel initMessage,
        int reporterId, string name)
    {
        IssueName = name;
        CreatedDate = DateTime.Now;
        LastUpdateDate = DateTime.Now;
        CurrentSeverity = Severity.Cosmetic;
        CurrentStatus = Status.Unopened;
        ReportedByUserId = reporterId;
        AssignedToUserId = 0;
        CommentList = commentList;
        CommentList.Add(initMessage);
    }

    public int Id { get; set; }
    public string? IssueName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public Severity CurrentSeverity { get; set; }
    public Status CurrentStatus { get; set; }
    public int ReportedByUserId { get; }
    public int AssignedToUserId { get; set; }
    public IList<MessageViewModel>? CommentList { get; }

    public void AddComment(MessageViewModel comment)
    {
        if (CommentList != null)
        {
            CommentList.Add(comment);
            LastUpdateDate = DateTime.Now;
        }
        
    }

    public void IncreaseSeverity()
    {
        // Severity.Critical is largest enum value
        if (CurrentSeverity < Severity.Critical)
        {
            CurrentSeverity += 1;
            LastUpdateDate = DateTime.Now;
        }
    }

    public void DecreaseSeverity()
    {
        // Severity.Cosmetic is smallest enum value
        if (CurrentSeverity > Severity.Cosmetic)
        {
            CurrentSeverity -= 1;
            LastUpdateDate = DateTime.Now;
        }
    }

    public void AssignTo(int userId)
    {
        AssignedToUserId = userId;
        LastUpdateDate = DateTime.Now;
    }
}


