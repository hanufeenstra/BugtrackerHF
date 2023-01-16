using BugtrackerHF.Models;

namespace BugtrackerHF.Services;

public interface IUserService
{
    Task<UserModel> PopulateIssueList(string authZeroId);
}