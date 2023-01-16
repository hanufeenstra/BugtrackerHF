using System.Linq.Expressions;
using BugtrackerHF.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace BugtrackerHF.DAL.GenericRepository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly BugtrackerHFContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(BugtrackerHFContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public virtual IEnumerable<TEntity> GetAll(
        Expression<Func<TEntity, bool>> filter,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = _dbSet;

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

    public virtual TEntity GetById(object id)
    {
        return _dbSet.Find(id);
    }

    public virtual void Insert(TEntity entityToInsert)
    {
        _dbSet.Add(entityToInsert);
    }

    public virtual void Update(TEntity entityToUpdate)
    {
        _dbSet.Attach(entityToUpdate);
        _context.Entry(entityToUpdate).State = EntityState.Modified;
    }

    public virtual void Delete(object id)
    {
        TEntity entityToDelete = _dbSet.Find(id);
        Delete(entityToDelete);
    }

    public virtual void Delete(TEntity entityToDelete)
    {
        if (_context.Entry(entityToDelete).State == EntityState.Detached)
        {
            _dbSet.Attach(entityToDelete);
        }
        _dbSet.Remove(entityToDelete);
    }
}