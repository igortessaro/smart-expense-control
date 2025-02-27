using AutoMapper;
using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Notification;
using SmartExpenseControl.Domain.Repositories;
using SmartExpenseControl.Domain.Services;

namespace SmartExpenseControl.Application.Commands.CreateExpense;

public class CreateExpenseHandler(
    IExpenseRepository expenseRepository,
    IExpenseGroupService expenseGroupService,
    IMapper mapper) : IRequestHandler<CreateExpenseCommand, Message<ExpenseSummary>>
{
    public async Task<Message<ExpenseSummary>> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        Message<ExpenseGroup> expenseGroupMessage = await expenseGroupService.GetOrCreateDefaultAsync(request.ExpenseGroupId, request.CreatedBy);
        if (!expenseGroupMessage.IsSuccess) return expenseGroupMessage.Notifications.ToArray();

        var expenseToAdd = mapper.Map<Expense>(request with { ExpenseGroupId = expenseGroupMessage.Payload!.Id });
        if (request.PayedBy.HasValue) expenseToAdd.Pay(request.PayedBy, request.PayedAt);

        var result = mapper.Map<ExpenseSummary>(await expenseRepository.AddAsync(expenseToAdd));
        return result;
    }
}
