using System.Linq.Expressions;
using BugtrackerHF.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace BugtrackerHF.DAL.GenericRepository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    public BugtrackerHFContext _context;
    public DbSet<T> _dbSet;

    public GenericRepository(BugtrackerHFContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public virtual IEnumerable<T> GetAll(
        Expression< Func< T, bool > > filter,
        Func< IQueryable< T >, IOrderedQueryable< T > > orderBy,
        string includeProperties = "")
    {
        IQueryable< T > query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
                     (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return orderBy(query).ToList();
        }
        else
        {
            return query.ToList();
        }
    }

    public virtual T GetById(object id)
    {
        return _dbSet.Find(id);
    }

    public virtual void Insert(T entityToInsert)
    {
        _dbSet.Add(entityToInsert);
    }

    public virtual void Update(T entityToUpdate)
    {
        _dbSet.Attach(entityToUpdate);
        _context.Entry(entityToUpdate).State = EntityState.Modified;
    }

    public virtual void Delete(object id)
    {
        T entityToDelete = _dbSet.Find(id);
        Delete(entityToDelete);
    }

    public virtual void Delete(T entityToDelete)
    {
        if (_context.Entry(entityToDelete).State == EntityState.Detached)
        {
            _dbSet.Attach(entityToDelete);
        }
        _dbSet.Remove(entityToDelete);
    }
}