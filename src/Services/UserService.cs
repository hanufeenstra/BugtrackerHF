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
        var user = await _userRepository.GetByAuthZeroIdAsync(authZeroId);

        var viewModel = new ProfileViewModel
        {
            UserNickname = user.UserNickname,
            UserEmail = user.UserEmail,
            UserPicture = user.UserPicture
        };

        return viewModel;
    }
}