using AutoMapper;
using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Commands.CreateExpense;

public class CreateExpenseHandler(
    IExpenseRepository expenseRepository,
    IExpenseGroupRepository expenseGroupRepository,
    IMapper mapper) : IRequestHandler<CreateExpenseCommand, ExpenseSummary>
{
    public async Task<ExpenseSummary> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        var expenseGroup = await expenseGroupRepository.GetByIdAsync(request.ExpenseGroupId) ??
                           await expenseGroupRepository.AddAsync(new ExpenseGroup("Default Expense Group", "Default Expense Group created automatically", 1));
        var expenseToAdd = mapper.Map<Expense>(request with { ExpenseGroupId = expenseGroup.Id });
        if (request.PayedBy.HasValue) expenseToAdd.Pay(request.PayedBy, request.PayedAt);

        return mapper.Map<ExpenseSummary>(await expenseRepository.AddAsync(expenseToAdd));
    }
}
