using BugtrackerHF.DAL.Data;
using BugtrackerHF.Models;
using Microsoft.EntityFrameworkCore;

namespace BugtrackerHF.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BugtrackerHFContext _context;

    public UserRepository(BugtrackerHFContext context)
    {
        _context = context;
    }

    public async Task<UserModel> AddUserAsync(UserModel user)
    {
        _context.UserModel.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<UserModel> GetByAuthZeroIdAsync(string authZeroId)
    {
        var user = await _context.UserModel
            .SingleOrDefaultAsync(u => u.AuthZeroId == authZeroId);

        return user;
    }

    /// <summary>
    /// Loads the UserModel.IssueList explicitly for the user related to authZeroId
    /// </summary>
    /// <param name="authZeroId"></param>
    /// <returns>UserModel object</returns>
    public async Task<UserModel> LoadIssuesByAuthZeroIdAsync(string authZeroId)
    {
        var user = await _context.UserModel
            .SingleAsync(u => u.AuthZeroId == authZeroId);

        user = await LoadIssuesAsync(user);
        return user;
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

        // Remember To check for null
        return user;
    }

    /// <summary>
    /// Overloaded Update taking User Id, the updated email and the updated nickname as parameters.
    /// Saves only the Email and Nickname properties to the context 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="email"></param>
    /// <param name="nickname"></param>
    public void Update(int id, string email, string nickname)
    {
        var updatedUser = _context.UserModel.Find(id);

        updatedUser.UserEmail = email;
        updatedUser.UserNickname = nickname;
        _context.SaveChanges();
    }

    /// <summary>
    /// Update UserModel
    /// </summary>
    /// <param name="user"></param>
    public void Update(UserModel user)
    {
        var updatedUser = _context.UserModel.Find(user.Id);
        updatedUser = user;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {

    }
}