using BugtrackerHF.DAL.UnitOfWork;
using BugtrackerHF.Models;
using BugtrackerHF.Models.ViewModels;

namespace BugtrackerHF.Services;

public class IssueService : IIssueService
{
    private readonly IUnitOfWork _unitOfWork;

    public IssueService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Takes authZeroId as parameter, populates the view specific model with a list of Issues related to the User. 
    /// </summary>
    /// <param name="authZeroId"></param>
    /// <returns>MyIssuesViewModel</returns>
    public async Task<MyIssuesViewModel> GetMyIssuesViewModel(string authZeroId)
    {
        var user = await _unitOfWork.UserRepository().LoadIssuesByAuthZeroIdAsync(authZeroId);

        var viewModel = new MyIssuesViewModel
        {
            Issues = user.IssueList
        };

        return viewModel;
    }
    /// <summary>
    /// Takes the issue id as parameter, returns a view specific model for the issue related to the issue id.
    /// </summary>
    /// <param name="issueId"></param>
    /// <returns>DisplayIssueViewModel</returns>
    public async Task<DisplayIssueViewModel> GetDisplayIssueViewModel(int issueId)
    {
        Console.WriteLine($"issueId: {issueId}");
        var issue = await _unitOfWork.IssueRepository().GetByIdAsync(issueId);
        Console.WriteLine($"issue.Id: {issue.Id}");
        
        var viewModel = new DisplayIssueViewModel
        {
           Id = issue.Id,
           LastUpdateDate = issue.LastUpdateDate,
           CreatedDate = issue.CreatedDate,
           CurrentSeverity = issue.CurrentSeverity,
           CurrentStatus = issue.CurrentStatus,
           IssueName = issue.IssueName,
           ReportedByUserId = issue.ReportedByUserId
        };
        return viewModel;
    }
    public async Task IncreaseIssueSeverity(int issueId)
    {
        var model = await _unitOfWork.IssueRepository().GetByIdAsync(issueId);

        // Severity.Critical is largest enum value
        if (model.CurrentSeverity < Severity.Critical)
        {
            model.CurrentSeverity += 1;
            model.LastUpdateDate = DateTime.Now;
        }
        _unitOfWork.IssueRepository().Update(model);
        _unitOfWork.Save();
    }

    public async Task DecreaseIssueSeverity(int issueId)
    {
        var issue = await _unitOfWork.IssueRepository().GetByIdAsync(issueId);

        // Severity.Cosmetic is smallest enum value
        if (issue.CurrentSeverity > Severity.Cosmetic)
        {
            issue.CurrentSeverity -= 1;
            issue.LastUpdateDate = DateTime.Now;
        }

        _unitOfWork.IssueRepository().Update(issue);
        _unitOfWork.Save();
    }


    public async Task AssignIssueToUser(int userId, IssueModel issue)
    {
        // Incomplete, need to implement removal from current user logic

        //var user = await _unitOfWork.UserRepository().GetByIdAsync(userId);
        
        issue.LastUpdateDate = DateTime.Now;
        //await _unitOfWork.UserRepository().LoadIssuesAsync(user);

        //user.IssueList.Add(issue);

    }

    /// <summary>
    /// Takes a populated view specific model as parameter, creates an IssueModel and saves
    /// it to the database, returns the issueId
    /// </summary>
    /// <param name="issue"></param>
    /// <returns>issueId</returns>
    public async Task<int> CreateNewIssue(CreateIssueViewModel issue)
    {
        var issueToSave = new IssueModel
        {
            IssueName = issue.Title,
            CreatedDate = DateTime.Now,
            CurrentSeverity = Severity.Cosmetic,
            CurrentStatus = Status.Unopened,
            LastUpdateDate = DateTime.Now,
            ReportedByUserId = issue.CreatedByUserId,
            MessageList = new List<MessageModel>
            {
                new MessageModel
                {
                    CreatedTime = DateTime.Now,
                    CreatedByUserId = issue.CreatedByUserId,
                    Message = issue.Description
                }
            }
        };
        await _unitOfWork.IssueRepository().InsertAsync(issueToSave);
        _unitOfWork.Save();
        
        return issueToSave.Id;
    }
}