using MediatR;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Queries.GetExpenses;

public class GetExpensesQueryHandler(IExpenseRepository expenseRepository)
    : IRequestHandler<GetExpensesQuery, IList<Expense>>
{
    public Task<IList<Expense>> Handle(GetExpensesQuery request, CancellationToken cancellationToken)
    {
        return expenseRepository.GetByUserIdAsync(request.UserId);
    }
}
