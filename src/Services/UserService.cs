using System.Security.Claims;
using BugtrackerHF.DAL.Repositories;
using BugtrackerHF.Models;

namespace BugtrackerHF.Services;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserModel> PopulateIssueList(string authZeroId)
    {
        var user = await _userRepository.LoadIssuesByAuthZeroIdAsync(authZeroId);
        return user;
    }
}