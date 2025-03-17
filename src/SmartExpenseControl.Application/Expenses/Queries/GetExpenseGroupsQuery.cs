using SmartExpenseControl.Domain.DataObjectTransfer;

namespace SmartExpenseControl.Application.Expenses.Queries;

public sealed class GetExpenseGroupsQuery(int pageNumber, int pageSize) : PaginationQuery<ExpenseGroupSummary>(pageNumber, pageSize);
