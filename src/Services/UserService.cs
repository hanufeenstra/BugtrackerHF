using System.Security.Claims;
using BugtrackerHF.DAL.Repositories;
using BugtrackerHF.DAL.UnitOfWork;
using BugtrackerHF.Models;
using BugtrackerHF.Models.ViewModels;

namespace BugtrackerHF.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ProfileViewModel> GetProfileViewModel(string authZeroId)
    {
        var user = await _unitOfWork.UserRepository().GetByAuthZeroIdAsync(authZeroId);

        var viewModel = new ProfileViewModel
        {
            UserNickname = user.UserNickname,
            UserEmail = user.UserEmail,
            UserPicture = user.UserPicture
        };

        return viewModel;
    }
}