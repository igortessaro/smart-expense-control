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
    IMapper mapper) : IRequestHandler<CreateExpenseCommand, MessageData<ExpenseSummary>>
{
    public async Task<MessageData<ExpenseSummary>> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        var expenseGroupMessage = await expenseGroupService.GetOrCreateDefaultAsync(request.ExpenseGroupId, request.CreatedBy);
        if (!expenseGroupMessage.IsSuccess) return expenseGroupMessage.ParseTo<ExpenseSummary>();

        var expenseToAdd = mapper.Map<Expense>(request with { ExpenseGroupId = expenseGroupMessage.Data!.Id });
        if (request.PayedBy.HasValue) expenseToAdd.Pay(request.PayedBy, request.PayedAt);

        var result = mapper.Map<ExpenseSummary>(await expenseRepository.AddAsync(expenseToAdd));
        return MessageData<ExpenseSummary>.CreateSuccess(result);
    }
}
