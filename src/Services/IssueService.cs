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