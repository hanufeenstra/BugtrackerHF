using System.Linq.Expressions;

namespace BugtrackerHF.src.DAL.GenericRepository;

public interface IGenericRepository<T> where T : class
{
    void Insert(T obj);
    IEnumerable<T> GetAll(
        Expression<Func<T, bool>> filter,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
        string includeProperties);

    T GetById(object id);
    void Update(T obj);
    void Delete(object id);
}