using AutoMapper;
using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Notification;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Commands.CreateExpense;

public class CreateExpenseHandler(
    IExpenseRepository expenseRepository,
    IExpenseGroupRepository expenseGroupRepository,
    IMapper mapper) : IRequestHandler<CreateExpenseCommand, MessageData<ExpenseSummary>>
{
    public async Task<MessageData<ExpenseSummary>> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        var expenseGroup = await expenseGroupRepository.GetByIdAsync(request.ExpenseGroupId) ??
                           await expenseGroupRepository.AddAsync(ExpenseGroup.CreateDefault(request.CreatedBy));
        var expenseToAdd = mapper.Map<Expense>(request with { ExpenseGroupId = expenseGroup.Id });
        if (request.PayedBy.HasValue) expenseToAdd.Pay(request.PayedBy, request.PayedAt);

        var result = mapper.Map<ExpenseSummary>(await expenseRepository.AddAsync(expenseToAdd));
        return MessageData<ExpenseSummary>.CreateSuccess(result);
    }
}
