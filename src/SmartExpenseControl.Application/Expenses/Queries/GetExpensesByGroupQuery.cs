using SmartExpenseControl.Domain.ExpenseGroups.Models;

namespace SmartExpenseControl.Application.Expenses.Queries;

public sealed class GetExpensesByGroupQuery(int id, int? periodExpenseId, int pageNumber, int pageSize)
    : PaginationQuery<ExpenseSummary>(pageNumber, pageSize)
{
    public int Id { get; } = id;
    public int? PeriodExpenseId { get; } = periodExpenseId;
}
