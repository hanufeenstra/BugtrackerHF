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
    private readonly IUserRepository _userRepository;
    private readonly IMessageRepository _messageRepository;
    private readonly IIssueRepository _issueRepository;
    private IDbContextTransaction _transaction;

    public UnitOfWork(
        BugtrackerHFContext context)
    {
        _context = context;
        _messageRepository = new MessageRepository(_context);
        _userRepository = new UserRepository(_context);
        _issueRepository = new IssueRepository(_context);
    }

    public IMessageRepository MessageRepository()
    {
        return _messageRepository;
    }

    public IUserRepository UserRepository()
    {
        return _userRepository;
    }

    public IIssueRepository IssueRepository()
    {
        return _issueRepository;
    }

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
