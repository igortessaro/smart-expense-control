using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Domain.Repositories;

public interface IExpenseRepository
{
    Task<Expense> GetByIdAsync(int id);
    Task<IEnumerable<Expense>> GetAllAsync();
    Task AddAsync(Expense expense);
    Task UpdateAsync(Expense expense);
    Task DeleteAsync(int id);
}