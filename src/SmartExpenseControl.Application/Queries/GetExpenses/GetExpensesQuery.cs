using MediatR;
using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Application.Queries.GetExpenses;

public record GetExpensesQuery : IRequest<IList<Expense>>
{
    public int UserId { get; init; }
}
