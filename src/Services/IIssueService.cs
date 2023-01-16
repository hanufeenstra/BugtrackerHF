using BugtrackerHF.Models.ViewModels;

namespace BugtrackerHF.Services;

public interface IIssueService
{
    Task<MyIssuesViewModel> GetMyIssuesViewModel(string authZeroId);
}