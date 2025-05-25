using AutoMapper;
using MediatR;
using SmartExpenseControl.Application.Expenses.Commands;
using SmartExpenseControl.Application.Expenses.Queries;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.ExpenseGroups;
using SmartExpenseControl.Domain.Repositories;
using SmartExpenseControl.Domain.Services;
using SmartExpenseControl.Domain.Shared;

namespace SmartExpenseControl.Application.Expenses.Handlers;

public sealed class ExpenseHandler(
    IExpenseRepository repository,
    IExpenseGroupService service,
    IMapper mapper) :
    IRequestHandler<CreateExpenseCommand, Notification<ExpenseSummary>>,
    IRequestHandler<UpdateExpenseCommand, Notification<ExpenseSummary>>,
    IRequestHandler<GetExpensesQuery, PagedResponseOffset<ExpenseSummary>>,
    IRequestHandler<GetSingleExpenseQuery, ExpenseSummary>,
    IRequestHandler<GetExpensesByGroupQuery, PagedResponseOffset<ExpenseSummary>>,
    IRequestHandler<DeleteExpenseCommand, Notification>
{
    public async Task<Notification<ExpenseSummary>> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        var expenseGroupMessage = await service.GetOrCreateDefaultAsync(request.ExpenseGroupId, request.CreatedBy);
        if (!expenseGroupMessage.IsSuccess) return expenseGroupMessage.Notifications.ToArray();

        var expenseToAdd = mapper.Map<Expense>(request with { ExpenseGroupId = request.ExpenseGroupId });
        if (request.PayedBy.HasValue) expenseToAdd.Pay(request.PayedBy, request.PayedAt);

        var result = mapper.Map<ExpenseSummary>(await repository.AddAsync(expenseToAdd));
        return result;
    }

    public async Task<Notification<ExpenseSummary>> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = await repository.GetAsync(request.Id);
        _ = expense?.Updated(request.Name, request.ExpenseTypeId, request.Amount, request.PaymentMethod, request.UpdatedBy);
        if (request.PayedBy.HasValue) expense?.Pay(request.PayedBy, request.PayedAt);
        var result = mapper.Map<ExpenseSummary>(await repository.UpdateAsync(expense!));
        return result;
    }

    public Task<PagedResponseOffset<ExpenseSummary>> Handle(GetExpensesQuery request, CancellationToken cancellationToken) =>
        repository.GetPagedAsync(new PagedRequest(request.PageNumber, request.PageSize), request.UserId, request.PeriodExpenseId);

    public async Task<ExpenseSummary> Handle(GetSingleExpenseQuery request, CancellationToken cancellationToken) =>
        mapper.Map<ExpenseSummary>(await repository.GetAsync(request.Id));

    public Task<PagedResponseOffset<ExpenseSummary>> Handle(GetExpensesByGroupQuery request, CancellationToken cancellationToken) =>
        repository.GetPagedAsync(new PagedRequest(request.PageNumber, request.PageSize), null, request.PeriodExpenseId);

    public async Task<Notification> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id);
        return Notification.Ok();
    }
}
