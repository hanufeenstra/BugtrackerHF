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

    // Constructor
    // Should be used whenever a new issue is created
    public IssueViewModel(UserViewModel creator, string name, Severity s)
    {
        IssueName = name;
        CommentList = new List<MessageViewModel>();
        var initMessage = new MessageViewModel()
        {
            CreatedTime = DateTime.Now,
            Message =  creator.UserNickname + " created new issue on " +  CreatedDate,
            ParentMassageId = 0,
            //ReceiverUserId = assignedTo.Id, 
            SenderUserId = creator.AuthZeroId
        };

        ReportedByUserId = creator.AuthZeroId;
        //AssignedToUserId = assignedTo.Id;
        CommentList.Add(initMessage);
        CurrentStatus = 0;
        CurrentSeverity = s;
        CreatedDate = DateTime.Now;
        LastUpdateDate = DateTime.Now;
    }

    public int Id { get; set; }
    public string IssueName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public Severity? CurrentSeverity { get; set; }
    public Status CurrentStatus { get; set; }
    public int ReportedByUserId { get; set; }
    public int? AssignedToUserId { get; set; }
    public List<MessageViewModel> CommentList { get; }

    public void AddComment(MessageViewModel comment)
    {
        CommentList.Add(comment);
    }

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

