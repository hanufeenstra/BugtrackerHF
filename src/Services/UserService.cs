using System.Security.Claims;
using BugtrackerHF.DAL.Repositories;
using BugtrackerHF.Models;
using BugtrackerHF.Models.ViewModels;

namespace BugtrackerHF.Services;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ProfileViewModel> GetProfileViewModel(string authZeroId)
    {
        await _userRepository.GetByAuthZeroIdAsync(authZeroId);

        return new ProfileViewModel();
    }
}