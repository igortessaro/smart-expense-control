using SmartExpenseControl.Domain.Shared;

namespace SmartExpenseControl.Domain.ExpenseGroups.Services;

public interface IExpenseGroupService
{
    Task<Notification<ExpenseGroup>> GetOrCreateDefaultAsync(int expenseGroupId, int userId);
}
