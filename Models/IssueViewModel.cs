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

    private readonly IList<IMessageViewModel> _commentList;
    private readonly IUserViewModel _creator;
    private Severity _currentSeverity;

    // Constructor for DI
    public IssueViewModel(IList<IMessageViewModel> commentList, 
        IMessageViewModel initMessage, 
        IUserViewModel creator, string name)
    {
        _commentList = commentList;
        _creator = creator;

        CreatedDate = DateTime.Now;
        IssueName = name;
        _commentList.Add(initMessage);
        _currentSeverity = Severity.Cosmetic;
        CurrentStatus = Status.Unopened;
        ReportedByUserId = creator.Id;
        AssignedToUserId = 0;
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
    public string IssueName { get; }
    public DateTime CreatedDate { get; }
    public DateTime LastUpdateDate { get; set; }

    public Severity CurrentSeverity
    {
        get { return _currentSeverity; }
    }

    public Status CurrentStatus { get; set; }
    public int ReportedByUserId { get; }
    public int? AssignedToUserId { get; }
    public ICollection<IMessageViewModel> CommentList 
    {
        get { return _commentList; }
    }

    public void AddComment(IMessageViewModel comment)
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
    public ICollection<IMessageViewModel> CommentList { get; }

    public void AddComment(IMessageViewModel comment);
    public void IncreaseSeverity();
    public void DecreaseSeverity();
}

