using SmartExpenseControl.Domain.ExpenseGroups.Repositories;
using SmartExpenseControl.Domain.Shared;

namespace SmartExpenseControl.Domain.ExpenseGroups.Services;

public sealed class ExpenseGroupService(IExpenseGroupRepository expenseGroupRepository) : IExpenseGroupService
{
    public async Task<Notification<ExpenseGroup>> GetOrCreateDefaultAsync(int expenseGroupId, int userId)
    {
        var expenseGroup = await expenseGroupRepository.GetByIdAsync(expenseGroupId);
        if (expenseGroup is not null) return expenseGroup;

        var expenseGroups = await expenseGroupRepository.GetAllByUser(userId);
        return !expenseGroups.Any() ?
            await expenseGroupRepository.AddAsync(ExpenseGroup.CreateDefault(userId)) :
            expenseGroups.First();
    }
}
