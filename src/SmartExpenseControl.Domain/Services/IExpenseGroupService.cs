using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Domain.Services;

public interface IExpenseGroupService
{
    Task<MessageData<ExpenseGroup>> GetOrCreateDefaultAsync(int expenseGroupId, int userId);
}
