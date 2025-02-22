using AutoMapper;
using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Queries.GetExpenses;

public sealed class GetExpensesHandler(IExpenseRepository expenseRepository, IMapper mapper)
    : IRequestHandler<GetExpensesQuery, PagedResponseOffset<ExpenseSummary>>, IRequestHandler<GetSingleExpenseQuery, ExpenseSummary>
{
    public Task<PagedResponseOffset<ExpenseSummary>> Handle(GetExpensesQuery request, CancellationToken cancellationToken) =>
        expenseRepository.GetByUserIdAsync(request.UserId, request.PageNumber, request.PageSize);

    public async Task<ExpenseSummary> Handle(GetSingleExpenseQuery request, CancellationToken cancellationToken) =>
        mapper.Map<ExpenseSummary>(await expenseRepository.GetByIdAsync(request.ExpenseId));
}
