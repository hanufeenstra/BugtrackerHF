using BugtrackerHF.DAL.Data;
using BugtrackerHF.Models;
using Microsoft.EntityFrameworkCore;

namespace BugtrackerHF.DAL.Repositories;


public interface IIssueRepository
{
    Task<IssueViewModel> AddAsync(IssueViewModel issue);
    Task<IssueViewModel> LoadMessagesAsync(IssueViewModel issue);
    Task<IssueViewModel> GetByIdAsync(int id);
}


public class IssueRepository : IIssueRepository
{
    private readonly BugtrackerHFContext _context;

    public IssueRepository(BugtrackerHFContext context)
    {
        _context = context;
    }

    public async Task<IssueViewModel> AddAsync(IssueViewModel issue)
    {
        _context.IssueViewModel.Add(issue);
        await _context.SaveChangesAsync();

        return issue;
    }

    /// <summary>
    /// Explicitly loads the message list associated with the issue parameter
    /// </summary>
    /// <param name="issue"></param>
    /// <returns></returns>
    public async Task<IssueViewModel> LoadMessagesAsync(IssueViewModel issue)
    {
        await _context.Entry(issue)
            .Collection(i => i.MessageList)
            .LoadAsync();

        return issue;
    }

    public async Task<IssueViewModel> GetByIdAsync(int id)
    {
        var issue = await _context.IssueViewModel
            .SingleOrDefaultAsync(i => i.Id == id);

        return issue;
    }
}
