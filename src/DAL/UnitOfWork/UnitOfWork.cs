//using BugtrackerHF.DAL.Data;
//using BugtrackerHF.DAL.SpecificRepository;
//using BugtrackerHF.DAL.GenericRepository;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Storage;

//namespace BugtrackerHF.DAL.UnitOfWork;

//public class UnitOfWork : IUnitOfWork, IDisposable
//{
//    private readonly BugtrackerHFContext _context;
//    private bool _disposed;
//    private GenericRepository<MessageRepository> _messageRepository;
//    private GenericRepository<UserRepository> _userRepository;
//    private IDbContextTransaction _transaction;

//    public UnitOfWork(BugtrackerHFContext context)
//    {
//        _context = context;
//    }

//    public void CreateTransaction()
//    {
//        _transaction = _context.Database.BeginTransaction();
//    }

//    public void Commit()
//    {
//        _transaction.Commit();
//    }

//    public void Rollback()
//    {
//        _transaction.Commit();
//        _transaction.Dispose();
//    }

//    public void Save()
//    {
//        _context.SaveChanges();
//    }

//    protected virtual void Dispose(bool disposing)
//    {
//        if (!_disposed)
//        {
//            if (disposing)
//            {
//                _context.Dispose();
//            }
//        }
//        _disposed = true;
//    }

//    public void Dispose()
//    {
//        Dispose(true);
//        GC.SuppressFinalize(this);
//    }

//    public GenericRepository<MessageRepository> MessageRepository
//    {
//        get
//        {
//            if (_messageRepository == null)
//            {
//                _messageRepository = new GenericRepository<MessageRepository>(_context);
//            }
//            return _messageRepository;
//        }
//    }

//    public GenericRepository<UserRepository> UserRepository
//    {
//        get
//        {
//            if (_userRepository == null)
//            {
//                _userRepository = new GenericRepository<UserRepository>(_context);
//            }
//            return _userRepository;
//        }
//    }
//}
