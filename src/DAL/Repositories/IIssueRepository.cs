using BugtrackerHF.src.Models;

namespace BugtrackerHF.src.DAL.Repositories;

public interface IIssueRepository
{
    Task<IssueModel> AddAsync(IssueModel issue);
    Task<IssueModel> LoadMessagesAsync(IssueModel issue);
    Task<IssueModel> GetByIdAsync(int id);
}