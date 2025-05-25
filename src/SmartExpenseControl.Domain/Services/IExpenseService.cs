using SmartExpenseControl.Domain.ExpenseGroups;

namespace SmartExpenseControl.Domain.Services;

public interface IExpenseService
{
    Task AddExpenseAsync(Expense expense);
}
