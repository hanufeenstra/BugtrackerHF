using BugtrackerHF.DAL.Data;
using BugtrackerHF.Models;
using Microsoft.EntityFrameworkCore;

namespace BugtrackerHF.DAL.Repositories;

public class UserRepository: IUserRepository
{
    private readonly BugtrackerHFContext _context;

    public UserRepository(BugtrackerHFContext context)
    {
        _context = context;
    }

    public async Task<UserViewModel> AddUserAsync(UserViewModel user)
    {
        _context.UserViewModel.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public UserViewModel GetByAuthZeroId(string authZeroId)
    {
        var user = _context.UserViewModel.SingleOrDefault(u => u.AuthZeroId == authZeroId);
        return user;
    }

    public async Task<UserViewModel> LoadIssuesByAuthZeroIdAsync(string authZeroId)
    {
        var user = await _context.UserViewModel.SingleAsync(u => u.AuthZeroId == authZeroId);
        user = await LoadIssuesAsync(user);
        return user;
    }

    /// <summary>
    /// Loads the UserViewModel.IssueList explicitly for the given user 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<UserViewModel> LoadIssuesAsync(UserViewModel user)
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
        var updatedUser = _context.UserViewModel.Find(id);

        updatedUser.UserEmail = email;
        updatedUser.UserNickname = nickname;
        _context.SaveChanges();
    }

    /// <summary>
    /// Update UserViewModel
    /// </summary>
    /// <param name="user"></param>
    public void Update(UserViewModel user)
    {
        var updatedUser = _context.UserViewModel.Find(user.Id);
        updatedUser = user;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {

    }
}