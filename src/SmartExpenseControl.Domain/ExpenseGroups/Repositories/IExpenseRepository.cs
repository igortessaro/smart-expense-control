using SmartExpenseControl.Domain.ExpenseGroups.Entities;
using SmartExpenseControl.Domain.ExpenseGroups.Models;
using SmartExpenseControl.Domain.Shared;

namespace SmartExpenseControl.Domain.ExpenseGroups.Repositories;

public interface IExpenseRepository : IRepository<Expense>
{
    Task<PagedResponseOffset<ExpenseSummary>> GetPagedAsync(PagedRequest pagedRequest, int? userId, int? periodExpenseId);

    Task<bool> ExistsAsync(int id);
}
