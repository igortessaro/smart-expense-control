using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Application.Queries.GetExpenseGroups;

public sealed class GetExpenseGroupsQuery(int pageNumber, int pageSize) : PaginationQuery<ExpenseGroup>(pageNumber, pageSize);
