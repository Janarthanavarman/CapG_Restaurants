using CapG.IRepositories;
using CapG.AppDbContext;
using Microsoft.EntityFrameworkCore;
using CapG.Models;
using System.Linq.Expressions;
namespace CapG.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DishDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(DishDbContext dishDbContext)
    {
        _context = dishDbContext;
        _dbSet = dishDbContext.Set<T>();
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetWithIncludesAsync(Func<IQueryable<T>, IQueryable<T>> includeProperties)
    {
        IQueryable<T> query = _dbSet;
        query = includeProperties(query);
        return await query.ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<IEnumerable<T>> GetItemsByDelegatsFilterAsync(FilterCondition<T> filter)
    {
        IQueryable<T> query = _dbSet;
        return query.AsEnumerable().Where(item => filter(item));
    }
    public async Task<IEnumerable<T>> GetItemsByExpFilterAsync(Expression<Func<T, bool>> filter)
    {
        IQueryable<T> query = _dbSet;
        return await query.Where(filter).ToListAsync();
    }
}