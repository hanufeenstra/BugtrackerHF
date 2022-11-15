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

public interface IIssueViewModel
{
    int Id { get; set; }
    string IssueName { get; }
    DateTime CreatedDate { get; }
    DateTime LastUpdateDate { get; }
    Severity CurrentSeverity { get; }
    Status CurrentStatus { get; set; }
    int ReportedByUserId { get; }
    int AssignedToUserId { get; }
    IList<IMessageViewModel> CommentList { get; }
    void AddComment(IMessageViewModel comment);
    void IncreaseSeverity();
    void DecreaseSeverity();
    void AssignTo(int userId);
}

public class IssueViewModel : IIssueViewModel
{

    private readonly IList<IMessageViewModel> _commentList;

    // Constructor for DI
    public IssueViewModel(
        IList<IMessageViewModel> commentList, 
        IMessageViewModel initMessage,
        int reporterId, string name)
    {
        IssueName = name;
        CreatedDate = DateTime.Now;
        LastUpdateDate = DateTime.Now;
        CurrentSeverity = Severity.Cosmetic;
        CurrentStatus = Status.Unopened;
        ReportedByUserId = reporterId;
        AssignedToUserId = 0;
        _commentList = commentList;
        _commentList.Add(initMessage);
    }

    public int Id { get; set; }
    public string IssueName { get; }
    public DateTime CreatedDate { get; }
    public DateTime LastUpdateDate { get; private set; }
    public Severity CurrentSeverity { get; private set; }
    public Status CurrentStatus { get; set; }
    public int ReportedByUserId { get; }
    public int AssignedToUserId { get; private set; }
    public IList<IMessageViewModel> CommentList => _commentList;

    public void AddComment(IMessageViewModel comment)
    {
        _commentList.Add(comment);
        LastUpdateDate = DateTime.Now;
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


