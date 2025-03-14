using Microsoft.EntityFrameworkCore;
using SmartExpenseControl.Domain.Repositories;
using SmartExpenseControl.Infrastructure.Data;

namespace SmartExpenseControl.Infrastructure.Repositories;

public abstract class BaseRepository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    protected BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T?> GetAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IList<T>> GetAllAsync()
    {
        return await Query().ToListAsync();
    }

    protected IQueryable<T> Query() => _dbSet.AsQueryable();

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<int> DeleteAsync(int id)
    {
        T? entity = await _dbSet.FindAsync(id);
        if (entity is null) return -1;

        _dbSet.Remove(entity);
        return await _context.SaveChangesAsync();
    }
}
