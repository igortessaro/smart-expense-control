using SmartExpenseControl.Domain.DataObjectTransfer;

namespace SmartExpenseControl.Application.Queries.GetExpenses;

public class GetExpensesQuery(int userId, int pageNumber, int pageSize)
    : PaginationQuery<ExpenseSummary>(pageNumber, pageSize)
{
    public int UserId { get; } = userId;
}
