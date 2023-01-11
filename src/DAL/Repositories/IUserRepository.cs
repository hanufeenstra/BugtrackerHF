using BugtrackerHF.Models;

namespace BugtrackerHF.src.DAL.Repositories;

public interface IUserRepository
{
    Task<UserModel> AddUserAsync(UserModel user);
    Task<UserModel> GetByAuthZeroIdAsync(string authZeroId);
    Task<UserModel> LoadIssuesAsync(UserModel user);
    Task<UserModel> LoadIssuesByAuthZeroIdAsync(string authZeroId);
    void Update(int id, string email, string nickname);
    void Update(UserModel user);
    void Delete(int id);

}