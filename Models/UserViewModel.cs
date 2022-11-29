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
    public Role UserRole { get; }
    IList<NotificationViewModel> GetNotificationLis();
    IList<IMessageViewModel> GetMessageList();
    IList<IIssueViewModel> GetIssueList();
}

public class UserViewModel : IUserViewModel
{
    private readonly IList<NotificationViewModel> _notificationList;
    private readonly IList<IMessageViewModel> _messageList;
    private readonly IList<IIssueViewModel> _issueList;

    // default constructor to keep EF Core happy
    public UserViewModel() { }

    // Overloaded constructor implementing DI
    public UserViewModel(
        IList<NotificationViewModel> notificationList,
        IList<IMessageViewModel> messageList,
        IList<IIssueViewModel> issueList, Role r)
    {
        _issueList = issueList;
        _notificationList = notificationList;
        _messageList = messageList;
        UserRole = r;
    }

    public int Id { get; set; }
    public string AuthZeroId { get; set; } = "";
    public string? UserNickname { get; set; }
    public string? UserEmail { get; set; }
    public Role UserRole { get; private set; }

    public IList<NotificationViewModel> GetNotificationLis()
    {
        return _notificationList;
    }

    public IList<IMessageViewModel> GetMessageList()
    {
        return _messageList;
    }

    public IList<IIssueViewModel> GetIssueList()
    {
        return _issueList;
    }
}
