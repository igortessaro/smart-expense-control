using AutoMapper;
using MediatR;
using SmartExpenseControl.Application.Expenses.Commands;
using SmartExpenseControl.Application.Expenses.Queries;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Notification;
using SmartExpenseControl.Domain.Repositories;
using SmartExpenseControl.Domain.Services;

namespace SmartExpenseControl.Application.Expenses;

public class ExpenseHandler(
    IExpenseRepository expenseRepository,
    IExpenseGroupService expenseGroupService,
    IMapper mapper) :
        IRequestHandler<CreateExpenseCommand, Message<ExpenseSummary>>,
        IRequestHandler<UpdateExpenseCommand, Message<ExpenseSummary>>,
        IRequestHandler<GetExpensesQuery, PagedResponseOffset<ExpenseSummary>>,
        IRequestHandler<GetSingleExpenseQuery, ExpenseSummary>,
        IRequestHandler<GetExpensesByGroupQuery, PagedResponseOffset<ExpenseSummary>>
{
    public async Task<Message<ExpenseSummary>> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        var expenseGroupMessage = await expenseGroupService.GetOrCreateDefaultAsync(request.ExpenseGroupId, request.CreatedBy);
        if (!expenseGroupMessage.IsSuccess) return expenseGroupMessage.Notifications.ToArray();

        var expenseToAdd = mapper.Map<Expense>(request with { ExpenseGroupId = request.ExpenseGroupId });
        if (request.PayedBy.HasValue) expenseToAdd.Pay(request.PayedBy, request.PayedAt);

        var result = mapper.Map<ExpenseSummary>(await expenseRepository.AddAsync(expenseToAdd));
        return result;
    }

    public async Task<Message<ExpenseSummary>> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = mapper.Map<Expense>(request);
        var result = mapper.Map<ExpenseSummary>(await expenseRepository.UpdateAsync(expense));
        return result;
    }

    public Task<PagedResponseOffset<ExpenseSummary>> Handle(GetExpensesQuery request, CancellationToken cancellationToken) =>
        expenseRepository.GetPagedAsync(new PagedRequest(request.PageNumber, request.PageSize), request.UserId, request.Period, null);

    public async Task<ExpenseSummary> Handle(GetSingleExpenseQuery request, CancellationToken cancellationToken) =>
        mapper.Map<ExpenseSummary>(await expenseRepository.GetAsync(request.ExpenseId));

    public Task<PagedResponseOffset<ExpenseSummary>> Handle(GetExpensesByGroupQuery request, CancellationToken cancellationToken) =>
        expenseRepository.GetPagedAsync(new PagedRequest(request.PageNumber, request.PageSize), null, request.Period, request.Id);
}
