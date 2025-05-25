using SmartExpenseControl.Domain.ExpenseGroups.Entities;
using SmartExpenseControl.Domain.ExpenseGroups.Repositories;

namespace SmartExpenseControl.Domain.ExpenseGroups.Services;

public class ExpenseService(IExpenseRepository expenseRepository) : IExpenseService
{
    public async Task AddExpenseAsync(Expense expense)
    {
        // Business logic for adding an expense
        await expenseRepository.AddAsync(expense);
    }

    // Other business logic methods
}
