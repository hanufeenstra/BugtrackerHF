using BugtrackerHF.Models;
using System.ComponentModel.DataAnnotations;

namespace BugtrackerHF.Models;

public class IssueModel
{
    public int Id { get; set; }
    public string? IssueName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public Severity CurrentSeverity { get; set; }
    public Status CurrentStatus { get; set; }
    public int ReportedByUserId { get; set; }
    public virtual IList<MessageModel>? MessageList { get; set; } = new List<MessageModel>();
}


