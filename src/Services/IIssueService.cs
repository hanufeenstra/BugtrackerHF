using BugtrackerHF.Models.ViewModels;

namespace BugtrackerHF.Services;

public interface IIssueService
{
    Task<ViewIssueViewModel> GetViewIssueViewModel(string authZeroId);
}