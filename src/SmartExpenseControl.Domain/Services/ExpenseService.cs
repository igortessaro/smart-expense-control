using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Domain.Services;

public class ExpenseService(IExpenseRepository expenseRepository)
{
    public async Task AddExpenseAsync(Expense expense)
    {
        // Business logic for adding an expense
        await expenseRepository.AddAsync(expense);
    }

    // Other business logic methods
}
