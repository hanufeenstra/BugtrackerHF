using BugtrackerHF.Models;
using BugtrackerHF.Models.ViewModels;

namespace BugtrackerHF.Services;

public interface IUserService
{
    Task<MyIssuesViewModel> GetMyIssuesViewModel(string authZeroId);
    Task<ProfileViewModel> GetProfileViewModel(string authZeroId);
}