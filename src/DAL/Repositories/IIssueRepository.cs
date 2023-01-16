using BugtrackerHF.Models;

namespace BugtrackerHF.DAL.Repositories;

public interface IIssueRepository
{
    Task<IssueModel> AddAsync(IssueModel issue);
    Task<IssueModel> LoadMessagesAsync(IssueModel issue);
    Task<IssueModel> GetByIdAsync(int id);
    Task UpdateAsync(IssueModel model);
}