using SmartExpenseControl.Domain.ExpenseGroups.Entities;

namespace SmartExpenseControl.Domain.ExpenseGroups.Services;

public interface IExpenseService
{
    Task AddExpenseAsync(Expense expense);
}
