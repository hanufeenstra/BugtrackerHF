using BugtrackerHF.Models.ViewModels;

namespace BugtrackerHF.Services;

public interface IIssueService
{
    Task<DisplayIssueViewModel> GetDisplayIssueViewModel(int id);
    Task<int> CreateNewIssue(CreateIssueViewModel issue);
}