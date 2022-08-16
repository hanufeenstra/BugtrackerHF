using System.ComponentModel.DataAnnotations;

namespace BugtrackerHF.Models;

public class UserViewModel
{
    public enum Role
    {
        TeamLeader = 0,
        FullStackDeveloper = 1,
        FrontEndDeveloper = 2,
        BackEndDeveloper = 3,
        UIUXEngineer = 4,
        DevOps = 5
    }

    public int Id { get; set; }
    public string AuthZeroId { get; set; } = "";
    public string? UserNickname { get; set; }
    public string? UserEmail { get; set; }
    public Role? UserRole { get; set; }
    public ICollection<NotificationViewModel>? NotificationList { get; set; } = new List<NotificationViewModel>();
    public ICollection<MessageViewModel>? MessageList { get; set; } = new List<MessageViewModel>();
    public ICollection<IssueViewModel>? IssueList { get; set; } = new List<IssueViewModel>();
}