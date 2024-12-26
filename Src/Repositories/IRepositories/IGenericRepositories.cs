using System.Linq.Expressions;

namespace CapG.IRepositories;
public interface IGenericRepository<T> where T : class
{
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<T> GetByIdAsync(int id);
    public Task<IEnumerable<T>> GetWithIncludesAsync(Func<IQueryable<T>, IQueryable<T>> includeProperties);    
    public Task<T> AddAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(int id);
    public Task<IEnumerable<T>> GetItemsByDelegatsFilterAsync(FilterCondition<T> filter);
    public Task<IEnumerable<T>> GetItemsByExpFilterAsync(Expression<Func<T, bool>> filter);
}