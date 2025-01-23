using MediatR;
using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Application.Queries.GetExpenses;

public class GetExpensesQuery : IRequest<IEnumerable<Expense>>
{
    public int UserId { get; set; }
}
