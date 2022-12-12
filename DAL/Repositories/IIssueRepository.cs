using BugtrackerHF.Models;

namespace BugtrackerHF.DAL.Repositories;

public interface IIssueRepository
{
    Task<IssueViewModel> AddAsync(IssueViewModel issue);
    Task<IssueViewModel> LoadMessagesAsync(IssueViewModel issue);
}