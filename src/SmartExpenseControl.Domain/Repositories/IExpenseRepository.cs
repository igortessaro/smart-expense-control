using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Domain.Repositories;

public interface IExpenseRepository : IRepository<Expense>
{
    Task<PagedResponseOffset<ExpenseSummary>> GetByUserIdAsync(int userId, int pageNumber, int pageSize);
}
