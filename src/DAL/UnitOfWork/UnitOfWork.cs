using BugtrackerHF.DAL.Data;
using BugtrackerHF.DAL.GenericRepository;
using BugtrackerHF.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BugtrackerHF.DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly BugtrackerHFContext _context;
    private bool _disposed;
    private IDbContextTransaction _transaction;

    public UnitOfWork(
        BugtrackerHFContext context, 
        IMessageRepository messageRepository,
        IUserRepository userRepository,
        IIssueRepository issueRepository)
    {
        _context = context;
        MessageRepository = messageRepository;
        UserRepository = userRepository;
        IssueRepository = issueRepository;
    }

    public IMessageRepository MessageRepository { get; }

    public IUserRepository UserRepository { get; }

    public IIssueRepository IssueRepository { get; }

    public void CreateTransaction()
    {
        _transaction = _context.Database.BeginTransaction();
    }

    public void Commit()
    {
        _transaction.Commit();
    }

    public void Rollback()
    {
        _transaction.Commit();
        _transaction.Dispose();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
