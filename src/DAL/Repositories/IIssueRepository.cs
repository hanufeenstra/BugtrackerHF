using BugtrackerHF.Models;
using BugtrackerHF.DAL.GenericRepository;

namespace BugtrackerHF.DAL.Repositories;

public interface IIssueRepository : IGenericRepository<IssueModel>
{
    Task<IssueModel> LoadMessagesAsync(IssueModel issue);
    Task<IssueModel> GetByIdAsync(int id);
}