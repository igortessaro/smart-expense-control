using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Domain.Repositories;

public interface IExpenseGroupRepository : IRepository<ExpenseGroup>
{
    Task<List<ExpenseGroup>> GetAllByUser(int userId);
}
