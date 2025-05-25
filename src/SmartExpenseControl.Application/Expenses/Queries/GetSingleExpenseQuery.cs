using MediatR;
using SmartExpenseControl.Domain.ExpenseGroups.Models;

namespace SmartExpenseControl.Application.Expenses.Queries;

public sealed class GetSingleExpenseQuery(int id) : IRequest<ExpenseSummary>
{
    public int Id { get; } = id;
}
