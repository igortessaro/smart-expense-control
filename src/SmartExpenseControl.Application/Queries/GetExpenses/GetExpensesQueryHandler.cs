using MediatR;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Queries.GetExpenses;

public class GetExpensesQueryHandler(IExpenseRepository expenseRepository) : IRequestHandler<GetExpensesQuery, IEnumerable<Expense>>
{
    public async Task<IEnumerable<Expense>> Handle(GetExpensesQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new List<Expense>());
        // return await _expenseRepository.GetByUserIdAsync(request.UserId);
    }
}
