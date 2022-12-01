using System.ComponentModel.DataAnnotations;
using System.Drawing.Text;
using BugtrackerHF.Models;

namespace BugtrackerHF.Models;

public enum Role
{
    TeamLeader = 0,
    FullStackDeveloper = 1,
    FrontEndDeveloper = 2,
    BackEndDeveloper = 3,
    UIUXEngineer = 4,
    DevOps = 5
}


public class UserViewModel
{

    // default constructor to keep EF Core happy
    public UserViewModel() { }

    // Overloaded constructor implementing DI
    public UserViewModel(
        IList<NotificationViewModel> notificationList,
        IList<MessageViewModel> messageList,
        IEnumerable<IssueViewModel> issueList, Role r)
    {
        IssueList = issueList;
        NotificationList = notificationList;
        MessageList = messageList;
        UserRole = r;
    }

    public int Id { get; set; }
    public string AuthZeroId { get; set; } = "";
    public string? UserNickname { get; set; }
    public string? UserEmail { get; set; }
    public Role? UserRole { get; set; }

    public IList<NotificationViewModel>? NotificationList { get; set; }
    public IList<MessageViewModel>? MessageList { get; set; }
    public IEnumerable<IssueViewModel>? IssueList { get; set; }

}
