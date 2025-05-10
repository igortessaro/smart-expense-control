using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Domain.Repositories;

public interface IExpenseRepository : IRepository<Expense>
{
    Task<PagedResponseOffset<ExpenseSummary>> GetPagedAsync(PagedRequest pagedRequest, int? userId, int? periodExpenseId);

    Task<bool> ExistsAsync(int id);
}
