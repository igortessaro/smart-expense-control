using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Notification;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Domain.Services;

public sealed class ExpenseGroupService(IExpenseGroupRepository expenseGroupRepository) : IExpenseGroupService
{
    public async Task<Message<ExpenseGroup>> GetOrCreateDefaultAsync(int expenseGroupId, int userId)
    {
        var expenseGroup = await expenseGroupRepository.GetByIdAsync(expenseGroupId);
        if (expenseGroup is not null) return Message<ExpenseGroup>.Ok(expenseGroup);

        var expenseGroups = await expenseGroupRepository.GetAllByUser(userId);
        return !expenseGroups.Any() ?
            Message<ExpenseGroup>.Ok(await expenseGroupRepository.AddAsync(ExpenseGroup.CreateDefault(userId))) :
            Message<ExpenseGroup>.Ok(expenseGroups.First());
    }
}
