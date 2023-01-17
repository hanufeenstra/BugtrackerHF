using BugtrackerHF.DAL.Data;
using BugtrackerHF.Models;
using BugtrackerHF.DAL.GenericRepository;

namespace BugtrackerHF.DAL.Repositories;

public class IssueRepository : GenericRepository<IssueModel>, IIssueRepository
{
    
    public IssueRepository(BugtrackerHFContext context)
        :base(context)
    {
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
}
