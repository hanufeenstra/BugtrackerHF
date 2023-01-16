using BugtrackerHF.DAL.Repositories;
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
    /// <returns>ViewIssueViewModel</returns>
    public async Task<ViewIssueViewModel> GetViewIssueViewModel(string authZeroId)
    {
        var user = await _userRepository.LoadIssuesByAuthZeroIdAsync(authZeroId);

        var viewModel = new ViewIssueViewModel
        {
            Issues = user.IssueList
        };

        return viewModel;
    }
}