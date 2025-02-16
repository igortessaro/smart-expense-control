using Microsoft.EntityFrameworkCore;
using SmartExpenseControl.Domain.Repositories;
using SmartExpenseControl.Infrastructure.Data;

namespace SmartExpenseControl.Infrastructure.Repositories;

public abstract class BaseRepository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    protected readonly DbSet<T> DbSet;

    protected BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        DbSet = _context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<IList<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    protected IQueryable<T> GetQueryable() => DbSet.AsQueryable();

    public async Task<T> AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        DbSet.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity is null) return -1;

        DbSet.Remove(entity);
        return await _context.SaveChangesAsync();
    }
}
