using SmartExpenseControl.Domain.ExpenseGroups;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Domain.Services;

public class ExpenseService(IExpenseRepository expenseRepository) : IExpenseService
{
    public async Task AddExpenseAsync(Expense expense)
    {
        // Business logic for adding an expense
        await expenseRepository.AddAsync(expense);
    }

    // Other business logic methods
}
