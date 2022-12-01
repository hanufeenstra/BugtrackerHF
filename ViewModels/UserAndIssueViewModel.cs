using BugtrackerHF.Models;

namespace BugtrackerHF.ViewModels;

public interface IUserAndIssueViewModel
{
    IUserViewModel User { get; }
    IEnumerable<IIssueViewModel> IssueList { get; }
}

public class UserAndIssueViewModel : IUserAndIssueViewModel
{
    public IUserViewModel User { get; }

    public IEnumerable<IIssueViewModel> IssueList { get; }

    public UserAndIssueViewModel(IUserViewModel user, IEnumerable<IIssueViewModel> issueList)
    {
        User = user;
        IssueList = issueList;
    }
}