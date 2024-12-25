namespace CapG.IRepositories;
public interface IGenericRepository<T> where T : class
{
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<T> GetByIdAsync(int id);
    public Task<IEnumerable<T>> GetWithIncludesAsync(Func<IQueryable<T>, IQueryable<T>> includeProperties);    
    public Task<T> AddAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(int id);
}