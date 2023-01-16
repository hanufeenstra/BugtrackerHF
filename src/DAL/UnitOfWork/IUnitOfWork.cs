using BugtrackerHF.DAL.GenericRepository;
using BugtrackerHF.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BugtrackerHF.DAL.UnitOfWork;

public interface IUnitOfWork
{
    void CreateTransaction();
    void Commit();
    void Rollback();
    void Save();
    IMessageRepository MessageRepository();
    IUserRepository UserRepository();
    IIssueRepository IssueRepository();
}