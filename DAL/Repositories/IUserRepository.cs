using BugtrackerHF.Models;

namespace BugtrackerHF.DAL.Repositories;

public interface IUserRepository
{
    Task<UserViewModel> AddUserAsync(UserViewModel user);
    Task<UserViewModel> GetByAuthZeroIdAsync(string authZeroId);
    Task<UserViewModel> LoadIssuesAsync(UserViewModel user);
    Task<UserViewModel> LoadIssuesByAuthZeroIdAsync(string authZeroId);
    void Update(int id, string email, string nickname);
    void Update(UserViewModel user);
    void Delete(int id);
    
}