namespace BugtrackerHF.Models;

public class UserViewModel
{
    public int AuthZeroId { get; set; }
    public string? UserNickname { get; set; }
    public string? UserEmail { get; set; }
    public string? UserRole { get; set; }
    public List<NotificationViewModel>? NotificationList { get; set; }
    public List<MessageViewModel>? MessageList { get; set; }
    public List<IssueViewModel>? IssueList { get; set; }
}