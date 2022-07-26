namespace BugtrackerHF.Models;

public class UserViewModel
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? UserSurname { get; set; }
    public string? UserRole { get; set; }
    public List<NotificationViewModel>? NotificationList { get; set; }
    public List<MessageViewModel>? MessageList { get; set; }
    public List<IssueViewModel>? IssueList { get; set; }
}