using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;

namespace SmartExpenseControl.Application.Queries.GetExpenses;

public sealed class GetSingleExpenseQuery(int expenseId) : IRequest<ExpenseSummary>
{
    public int ExpenseId { get; } = expenseId;
}
