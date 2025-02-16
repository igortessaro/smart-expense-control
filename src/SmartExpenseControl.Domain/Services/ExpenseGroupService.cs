using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Notification;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Domain.Services;

public sealed class ExpenseGroupService(IExpenseGroupRepository expenseGroupRepository) : IExpenseGroupService
{
    public async Task<MessageData<ExpenseGroup>> GetOrCreateDefaultAsync(int expenseGroupId, int userId)
    {
        var expenseGroup = await expenseGroupRepository.GetByIdAsync(expenseGroupId);
        if (expenseGroup is not null) return new MessageData<ExpenseGroup>(expenseGroup);

        var expenseGroups = await expenseGroupRepository.GetAllByUser(userId);
        return !expenseGroups.Any() ?
            new MessageData<ExpenseGroup>(await expenseGroupRepository.AddAsync(ExpenseGroup.CreateDefault(userId))) :
            new MessageData<ExpenseGroup>(expenseGroups.First());
    }
}
