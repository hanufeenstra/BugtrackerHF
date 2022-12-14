using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugtrackerHF.Models;

public class IssueViewModel
{
    public IssueViewModel()
    {
    }

    public IssueViewModel(
        string name,
        int reportedByUserId,
        MessageViewModel parentMessage)
    {
        IssueName = name;
        CreatedDate = DateTime.Now;
        LastUpdateDate = DateTime.Now;
        CurrentSeverity = Severity.Cosmetic;
        CurrentStatus = Status.Unopened;
        ReportedByUserId = reportedByUserId;
        MessageList = new List<MessageViewModel>();
        MessageList.Add(parentMessage);
    }

    public int Id { get; set; }
    [Required]
    public string? IssueName { get; set; }
    [NotMapped]
    [Required]
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public Severity CurrentSeverity { get; set; }
    public Status CurrentStatus { get; set; }
    public int ReportedByUserId { get; }
    public virtual IList<MessageViewModel>? MessageList { get; set; } = new List<MessageViewModel>();

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

    public void AddInitMessage(int id)
    {
        MessageList.Add(new MessageViewModel(id,
                "Created on " + DateTime.Now + ".\\r\\n" + Description));
    }
}


