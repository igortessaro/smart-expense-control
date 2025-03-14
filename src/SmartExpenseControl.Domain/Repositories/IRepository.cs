namespace SmartExpenseControl.Domain.Repositories;

public interface IRepository<T> where T : class
{
    Task<T?> GetAsync(int id);
    Task<IList<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<int> DeleteAsync(int id);
}
