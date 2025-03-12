using AutoMapper;
using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Queries.GetExpenses;

public sealed class GetExpensesHandler(IExpenseRepository expenseRepository, IMapper mapper)
    : IRequestHandler<GetExpensesQuery, PagedResponseOffset<ExpenseSummary>>,
        IRequestHandler<GetSingleExpenseQuery, ExpenseSummary>,
        IRequestHandler<GetExpensesByGroupQuery, PagedResponseOffset<ExpenseSummary>>
{
    public Task<PagedResponseOffset<ExpenseSummary>> Handle(GetExpensesQuery request, CancellationToken cancellationToken) =>
        expenseRepository.GetPagedAsync(new PagedRequest(request.PageNumber, request.PageSize), request.UserId, request.Period, null);

    public async Task<ExpenseSummary> Handle(GetSingleExpenseQuery request, CancellationToken cancellationToken) =>
        mapper.Map<ExpenseSummary>(await expenseRepository.GetByIdAsync(request.ExpenseId));

    public Task<PagedResponseOffset<ExpenseSummary>> Handle(GetExpensesByGroupQuery request, CancellationToken cancellationToken) =>
        expenseRepository.GetPagedAsync(new PagedRequest(request.PageNumber, request.PageSize), null, request.Period, request.Id);
}
