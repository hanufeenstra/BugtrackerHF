using System.ComponentModel.DataAnnotations;

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

public interface IUserViewModel
{
    int Id { get; set; }
    string AuthZeroId { get; set; }
    string? UserNickname { get; set; }
    string? UserEmail { get; set; }
    Role GetUserRole();
    ICollection<NotificationViewModel> GetNotificationLis();
    ICollection<MessageViewModel> GetMessageList();
    ICollection<IIssueViewModel> GetIssueList();
}

public class UserViewModel : IUserViewModel
{
    private readonly ICollection<NotificationViewModel> _notificationList;
    private readonly ICollection<MessageViewModel> _messageList;
    private readonly ICollection<IIssueViewModel> _issueList;
    private readonly Role _role;


    // Constructor implementing DI
    public UserViewModel(
        ICollection<NotificationViewModel> notificationList,
        ICollection<MessageViewModel> messageList, 
        ICollection<IIssueViewModel> issueList, Role r)
    {
        _issueList = issueList;
        _notificationList = notificationList;
        _messageList = messageList;
        _role = r;

    }

    public int Id { get; set; }
    public string AuthZeroId { get; set; } = "";
    public string? UserNickname { get; set; }
    public string? UserEmail { get; set; }

    public Role GetUserRole()
    {
        return _role;
    }

    public ICollection<NotificationViewModel> GetNotificationLis()
    {
        return _notificationList;
    }

    public ICollection<MessageViewModel> GetMessageList()
    {
        return _messageList;
    }

    public ICollection<IIssueViewModel> GetIssueList()
    {
        return _issueList;
    }
}
