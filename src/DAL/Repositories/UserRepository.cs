using BugtrackerHF.DAL.Data;
using BugtrackerHF.DAL.GenericRepository;
using BugtrackerHF.Models;
using Microsoft.EntityFrameworkCore;

namespace BugtrackerHF.DAL.Repositories;

public class UserRepository : GenericRepository<UserModel>, IUserRepository
{
    public UserRepository(BugtrackerHFContext context)
        :base(context)
    {
    }

    /// <summary>
    /// Finds the UserModal for the user related to the authZeroId user claim
    /// </summary>
    /// <param name="authZeroId"></param>
    /// <returns>UserModel</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<UserModel> GetByAuthZeroIdAsync(string authZeroId)
    {
        if (authZeroId == null) throw new ArgumentNullException(nameof(authZeroId));

        return await _context.UserModel
            .SingleOrDefaultAsync(u => u.AuthZeroId == authZeroId);
    }

    public async Task<UserModel> GetByIdAsync(int id)
    {
        return await _context.UserModel
            .SingleOrDefaultAsync(u => u.Id == id);
    }
    /// <summary>
    /// Loads the UserModel.IssueList explicitly for the user related to the authZeroId user claim
    /// </summary>
    /// <param name="authZeroId"></param>
    /// <returns>UserModel object</returns>
    public async Task<UserModel> LoadIssuesByAuthZeroIdAsync(string authZeroId)
    {
        
        // Add method to check for completed issues and only load open issues
        if (authZeroId == null) throw new ArgumentNullException(nameof(authZeroId));

        var user = await _context.UserModel
            .SingleAsync(u => u.AuthZeroId == authZeroId);

        return await LoadIssuesAsync(user);
    }

    /// <summary>
    /// Loads the UserModel.IssueList explicitly for the given user 
    /// </summary>
    /// <param name="user"></param>
    /// <returns>UserModel object</returns>
    public async Task<UserModel> LoadIssuesAsync(UserModel user)
    {
        await _context.Entry(user)
            .Collection(u => u.IssueList)
            .LoadAsync();

        return user;
    }
}