using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Domain.Repositories;

public interface IExpenseRepository : IRepository<Expense>
{
    Task<IList<Expense>> GetByUserIdAsync(int userId);
}