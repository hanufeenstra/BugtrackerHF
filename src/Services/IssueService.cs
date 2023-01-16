using BugtrackerHF.DAL.Repositories;
using BugtrackerHF.Models;
using BugtrackerHF.Models.ViewModels;

namespace BugtrackerHF.Services;

public class IssueService : IIssueService
{
    private readonly IUserRepository _userRepository;
    private readonly IIssueRepository _issueRepository;

    public IssueService(
        IUserRepository userRepository, 
        IIssueRepository issueRepository)
    {
        _userRepository = userRepository;
        _issueRepository = issueRepository;
    }

    /// <summary>
    /// Takes authZeroId as parameter, populates the ViewModel with a list of Issues related to the User. 
    /// </summary>
    /// <param name="authZeroId"></param>
    /// <returns>MyIssuesViewModel</returns>
    public async Task<MyIssuesViewModel> GetMyIssuesViewModel(string authZeroId)
    {
        var user = await _userRepository.LoadIssuesByAuthZeroIdAsync(authZeroId);

        var viewModel = new MyIssuesViewModel
        {
            Issues = user.IssueList
        };

        return viewModel;
    }

    public void IncreaseIssueSeverity(int issueId)
    {
        // Severity.Critical is largest enum value
        if (CurrentSeverity < Severity.Critical)
        {
            CurrentSeverity += 1;
            LastUpdateDate = DateTime.Now;
        }
    }

    public async Task DecreaseIssueSeverity(int issueId)
    {
        var model = await _issueRepository.GetByIdAsync(issueId);

        // Severity.Cosmetic is smallest enum value
        if (model.CurrentSeverity > Severity.Cosmetic)
        {
            model.CurrentSeverity -= 1;
            model.LastUpdateDate = DateTime.Now;
        }

        await _issueRepository.UpdateAsync(model);
    }

    public void AssignIssueToUser(int userId)
    {
        //AssignedToUserId = userId;
        LastUpdateDate = DateTime.Now;
    }
}