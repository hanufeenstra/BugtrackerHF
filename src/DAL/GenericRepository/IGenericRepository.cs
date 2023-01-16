using System.Linq.Expressions;

namespace BugtrackerHF.DAL.GenericRepository;

public interface IGenericRepository<T> where T : class
{
    Task InsertAsync(T obj);
    Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>> filter,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
        string includeProperties);

    Task<T> GetByIdAsync(int id);
    void Update(T obj);
    void Delete(object id);
}