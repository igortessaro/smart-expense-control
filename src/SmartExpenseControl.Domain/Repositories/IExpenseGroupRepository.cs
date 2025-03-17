using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Domain.Repositories;

public interface IExpenseGroupRepository : IRepository<ExpenseGroup>
{
    Task<List<ExpenseGroup>> GetAllByUser(int userId);
    Task<ExpenseGroup?> GetByIdAsync(int id);
    Task<PagedResponseOffset<ExpenseGroupSummary>> GetPagedAsync(PagedRequest pagedRequest);
    Task<bool> ExistsAsync(int id);
    Task<bool> ExistsAsync(string name, int userId);
}
