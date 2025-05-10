using SmartExpenseControl.Domain.DataObjectTransfer;

namespace SmartExpenseControl.Application.Expenses.Queries;

public sealed class GetExpensesQuery(int userId, int? periodExpenseId, int pageNumber, int pageSize)
    : PaginationQuery<ExpenseSummary>(pageNumber, pageSize)
{
    public int UserId { get; } = userId;
    public int? PeriodExpenseId { get; } = periodExpenseId;
}
