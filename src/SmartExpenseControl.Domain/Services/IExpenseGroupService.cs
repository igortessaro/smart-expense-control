using SmartExpenseControl.Domain.ExpenseGroups;
using SmartExpenseControl.Domain.Shared;

namespace SmartExpenseControl.Domain.Services;

public interface IExpenseGroupService
{
    Task<Notification<ExpenseGroup>> GetOrCreateDefaultAsync(int expenseGroupId, int userId);
}
