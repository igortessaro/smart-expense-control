using SmartExpenseControl.Domain.DataObjectTransfer;

namespace SmartExpenseControl.Application.Expenses.Queries;

public sealed class GetExpensesQuery(int userId, string period, int pageNumber, int pageSize)
    : PaginationQuery<ExpenseSummary>(pageNumber, pageSize)
{
    public int UserId { get; } = userId;
    public string Period { get; } = period;
}
