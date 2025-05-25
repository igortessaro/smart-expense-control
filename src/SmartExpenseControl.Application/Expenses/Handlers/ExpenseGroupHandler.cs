using AutoMapper;
using MediatR;
using SmartExpenseControl.Application.Commands.DeleteExpenseGroup;
using SmartExpenseControl.Application.Expenses.Commands;
using SmartExpenseControl.Application.Expenses.Queries;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.ExpenseGroups;
using SmartExpenseControl.Domain.Repositories;
using SmartExpenseControl.Domain.Shared;
using Notification = SmartExpenseControl.Domain.Shared.Notification;

namespace SmartExpenseControl.Application.Expenses.Handlers;

public sealed class ExpenseGroupHandler(IMapper mapper, IExpenseGroupRepository repository) :
    IRequestHandler<GetSingleExpenseGroupQuery, ExpenseGroupSummary>,
    IRequestHandler<GetExpenseGroupsQuery, PagedResponseOffset<ExpenseGroupSummary>>,
    IRequestHandler<CreateExpenseGroupCommand, Notification<ExpenseGroupSummary>>,
    IRequestHandler<UpdateExpenseGroupCommand, Notification<ExpenseGroupSummary>>,
    IRequestHandler<DeleteExpenseGroupCommand, Notification>
{
    public async Task<ExpenseGroupSummary> Handle(GetSingleExpenseGroupQuery request, CancellationToken cancellationToken) =>
        mapper.Map<ExpenseGroupSummary>(await repository.GetAsync(request.Id));

    public async Task<PagedResponseOffset<ExpenseGroupSummary>> Handle(GetExpenseGroupsQuery request, CancellationToken cancellationToken) =>
        await repository.GetPagedAsync(new PagedRequest(request.PageNumber, request.PageSize));

    public async Task<Notification<ExpenseGroupSummary>> Handle(CreateExpenseGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<ExpenseGroup>(request);
        var result = mapper.Map<ExpenseGroupSummary>(await repository.AddAsync(entity));
        return result;
    }

    public async Task<Notification<ExpenseGroupSummary>> Handle(UpdateExpenseGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetAsync(request.Id);
        _ = entity?.Update(request.Name, request.Description, request.UpdatedBy);
        var result = mapper.Map<ExpenseGroupSummary>(await repository.UpdateAsync(entity!));
        return result;
    }

    public async Task<Notification> Handle(DeleteExpenseGroupCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id);
        return Notification.Ok();
    }
}

