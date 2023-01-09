using BugtrackerHF.DAL.Data;
using BugtrackerHF.Models;
using Microsoft.EntityFrameworkCore;

namespace BugtrackerHF.DAL.Repositories;

public class IssueRepository : IIssueRepository
{
    private readonly BugtrackerHFContext _context;

    public IssueRepository(BugtrackerHFContext context)
    {
        _context = context;
    }

    public async Task<IssueModel> AddAsync(IssueModel issue)
    {
        _context.IssueModel.Add(issue);
        await _context.SaveChangesAsync();

        return issue;
    }

    /// <summary>
    /// Explicitly loads the message list associated with the issue parameter
    /// </summary>
    /// <param name="issue"></param>
    /// <returns></returns>
    public async Task<IssueModel> LoadMessagesAsync(IssueModel issue)
    {
        await _context.Entry(issue)
            .Collection(i => i.MessageList)
            .LoadAsync();

        return issue;
    }

    public async Task<IssueModel> GetByIdAsync(int id)
    {
        var issue = await _context.IssueModel
            .SingleOrDefaultAsync(i => i.Id == id);

        return issue;
    }
}
