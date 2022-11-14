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

public class IssueViewModel : IIssueViewModel
{

    private readonly List<MessageViewModel> _commentList;
    private readonly MessageViewModel _initMessage;
    private readonly UserViewModel _creator;
    private Severity _currentSeverity;
    private Status _currentStatus;

    // Constructor for DI
    public IssueViewModel(List<MessageViewModel> commentList, 
        MessageViewModel initMessage, UserViewModel creator, string name)
    {
        _commentList = commentList;
        _initMessage = initMessage;
        _creator = creator;

        CreatedDate = DateTime.Now;
        IssueName = name;
        _commentList.Add(_initMessage);
        _currentSeverity = Severity.Cosmetic;
        _currentStatus = Status.Unopened;
        ReportedByUserId = creator.Id;
    }

    // Constructor
    // Should be used whenever a new issue is created
    //public IssueViewModel(UserViewModel creator, string name, Severity s)
    //{
    //    IssueName = name;
    //    _commentList = new List<MessageViewModel>();
    //    var initMessage = new MessageViewModel()
    //    {
    //        CreatedTime = DateTime.Now,
    //        Message =  creator.UserNickname + " created new issue on " +  CreatedDate,
    //        ParentId = 0,
    //        //ReceiverUserId = assignedTo.Id, 
    //        SenderUserId = creator.Id
    //    };

    //    ReportedByUserId = creator.Id;
    //    //AssignedToUserId = assignedTo.Id;
    //    CommentList.Add(initMessage);
    //    CurrentStatus = 0;
    //    CurrentSeverity = s;
    //    CreatedDate = DateTime.Now;
    //    LastUpdateDate = DateTime.Now;
    //}

    public int Id { get; set; }
    public string? IssueName { get; set; }
    public DateTime CreatedDate { get; }
    public DateTime LastUpdateDate { get; set; }
    public Severity CurrentSeverity { get; }
    public Status CurrentStatus { get; }
    public int ReportedByUserId { get; }
    public int? AssignedToUserId { get; }
    public ICollection<MessageViewModel>? CommentList { get; }

    public void AddComment(MessageViewModel comment)
    {
        _commentList.Add(comment);
    }

    public void IncreaseSeverity()
    {
        // Severity.Critical is largest enum value
        if (_currentSeverity < Severity.Critical)
        {
            _currentSeverity += 1;
        }
    }

    public void DecreaseSeverity()
    {
        // Severity.Cosmetic is smallest enum value
        if (_currentSeverity > Severity.Cosmetic)
        {
            _currentSeverity -= 1;
        }
    }

    public void SetStatus (Status s)
    {
        _currentStatus = s;
    }

}

public interface IIssueViewModel
{
    public int Id { get; set; }
    public string? IssueName { get; }
    public DateTime CreatedDate { get; }
    public DateTime LastUpdateDate { get; }
    public Severity CurrentSeverity { get; }
    public Status CurrentStatus { get; }
    public int ReportedByUserId { get; }
    public int? AssignedToUserId { get; }
    public ICollection<MessageViewModel>? CommentList { get; }

    public void AddComment(MessageViewModel comment);
    public void IncreaseSeverity();
    public void DecreaseSeverity();
    public void SetStatus(Status s);
}

