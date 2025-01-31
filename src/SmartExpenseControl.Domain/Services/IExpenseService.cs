using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Domain.Services;

public interface IExpenseService
{
    Task AddExpenseAsync(Expense expense);
}