using AutoMapper;
using MediatR;
using SmartExpenseControl.Application.Commands.DeleteExpenseGroup;
using SmartExpenseControl.Application.Expenses.Commands;
using SmartExpenseControl.Application.Expenses.Queries;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Notification;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Expenses.Handlers;

public sealed class ExpenseGroupHandler(IMapper mapper, IExpenseGroupRepository repository) :
    IRequestHandler<GetSingleExpenseGroupQuery, ExpenseGroupSummary>,
    IRequestHandler<GetExpenseGroupsQuery, PagedResponseOffset<ExpenseGroupSummary>>,
    IRequestHandler<CreateExpenseGroupCommand, Message<ExpenseGroupSummary>>,
    IRequestHandler<UpdateExpenseGroupCommand, Message<ExpenseGroupSummary>>,
    IRequestHandler<DeleteExpenseGroupCommand, Message>
{
    public async Task<ExpenseGroupSummary> Handle(GetSingleExpenseGroupQuery request, CancellationToken cancellationToken) =>
        mapper.Map<ExpenseGroupSummary>(await repository.GetAsync(request.Id));

    public async Task<PagedResponseOffset<ExpenseGroupSummary>> Handle(GetExpenseGroupsQuery request, CancellationToken cancellationToken) =>
        await repository.GetPagedAsync(new PagedRequest(request.PageNumber, request.PageSize));

    public async Task<Message<ExpenseGroupSummary>> Handle(CreateExpenseGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<ExpenseGroup>(request);
        var result = mapper.Map<ExpenseGroupSummary>(await repository.AddAsync(entity));
        return result;
    }

    public async Task<Message<ExpenseGroupSummary>> Handle(UpdateExpenseGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetAsync(request.Id);
        _ = entity?.Update(request.Name, request.Description, request.UpdatedBy);
        var result = mapper.Map<ExpenseGroupSummary>(await repository.UpdateAsync(entity!));
        return result;
    }

    public async Task<Message> Handle(DeleteExpenseGroupCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id);
        return Message.Ok();
    }
}

