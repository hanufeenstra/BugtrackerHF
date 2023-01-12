using BugtrackerHF.Models;
using System.ComponentModel.DataAnnotations;

namespace BugtrackerHF.Models;

public class IssueModel
{
    public IssueModel()
    {
    }

    public IssueModel(
        string name,
        int reportedByUserId,
        MessageModel parentMessage)
    {
        IssueName = name;
        CreatedDate = DateTime.Now;
        LastUpdateDate = DateTime.Now;
        CurrentSeverity = Severity.Cosmetic;
        CurrentStatus = Status.Unopened;
        ReportedByUserId = reportedByUserId;
        MessageList = new List<MessageModel>
        {
            parentMessage
        };
    }

    public int Id { get; set; }
    [Required]
    public string? IssueName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public Severity CurrentSeverity { get; set; }
    public Status CurrentStatus { get; set; }
    public int ReportedByUserId { get; }
    public virtual IList<MessageModel>? MessageList { get; set; } = new List<MessageModel>();

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
        //AssignedToUserId = userId;
        LastUpdateDate = DateTime.Now;
    }
}


