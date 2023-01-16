using BugtrackerHF.DAL.GenericRepository;
using BugtrackerHF.Models;

namespace BugtrackerHF.DAL.Repositories;

public interface IUserRepository : IGenericRepository<UserModel>
{
    Task<UserModel> GetByAuthZeroIdAsync(string authZeroId);
    Task<UserModel> LoadIssuesAsync(UserModel user);
    Task<UserModel> LoadIssuesByAuthZeroIdAsync(string authZeroId);
}