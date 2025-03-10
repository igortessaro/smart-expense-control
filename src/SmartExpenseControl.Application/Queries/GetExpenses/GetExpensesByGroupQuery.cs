using SmartExpenseControl.Domain.DataObjectTransfer;

namespace SmartExpenseControl.Application.Queries.GetExpensesByGroup;

public sealed class GetExpensesByGroupQuery(int id, string period, int pageNumber, int pageSize)
    : PaginationQuery<ExpenseSummary>(pageNumber, pageSize)
{
    public int Id { get; } = id;
    public string Period { get; } = period;
}
