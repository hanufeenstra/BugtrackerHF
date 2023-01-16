using BugtrackerHF.Models;
using BugtrackerHF.Models.ViewModels;

namespace BugtrackerHF.Services;

public interface IUserService
{
    Task<ProfileViewModel> GetProfileViewModel(string authZeroId);
}