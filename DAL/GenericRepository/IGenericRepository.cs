using System.Linq.Expressions;

namespace BugtrackerHF.DAL.GenericRepository;

public interface IGenericRepository<T> where T : class
{
    IEnumerable<T> GetAll(
        Expression<Func<T, bool>> filter,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
        string includeProperties);

    T GetById(object id);
    void Insert(T obj);
    void Update(T obj);
    void Delete(object id);
}