using SmartExpenseControl.Domain.ExpenseGroups.Models;
using SmartExpenseControl.Domain.Shared;

namespace SmartExpenseControl.Domain.ExpenseGroups.Repositories;

public interface IExpenseGroupRepository : IRepository<ExpenseGroup>
{
    Task<List<ExpenseGroup>> GetAllByUser(int userId);
    Task<ExpenseGroup?> GetByIdAsync(int id);
    Task<PagedResponseOffset<ExpenseGroupSummary>> GetPagedAsync(PagedRequest pagedRequest);
    Task<bool> ExistsAsync(int id);
    Task<bool> ExistsAsync(string name, int userId);
}
