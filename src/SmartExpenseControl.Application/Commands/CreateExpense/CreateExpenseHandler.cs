using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Commands.CreateExpense;

public class CreateExpenseHandler(
    IExpenseRepository expenseRepository,
    IExpenseGroupRepository expenseGroupRepository) : IRequestHandler<CreateExpenseCommand, ExpenseSummary>
{
    public async Task<ExpenseSummary> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        var expenseGroup = await expenseGroupRepository.GetByIdAsync(request.ExpenseGroupId);
        if (expenseGroup is null)
        {
            var newExpenseGroup = new ExpenseGroup("Default Expense Group", "Default Expense Group created automatically", 1);
            await expenseGroupRepository.AddAsync(newExpenseGroup);
            expenseGroup = newExpenseGroup;
        }

        var expenseToAdd = new Expense(expenseGroup.Id, request.Name, request.Tag, request.Amount, request.PaymentMethod, request.CreatedBy);
        if (request.PayedBy.HasValue)
        {
            expenseToAdd.Pay(request.PayedBy, request.PayedAt);
        }

        await expenseRepository.AddAsync(expenseToAdd);

        return new ExpenseSummary()
        {
            Id = expenseToAdd.Id,
            Name = expenseToAdd.Name,
            Tag = expenseToAdd.Tag,
            Amount = expenseToAdd.Amount,
            CreatedBy = expenseToAdd.CreatedBy,
            PayedAt = expenseToAdd.PayedAt,
            PayedBy = expenseToAdd.PayedBy,
            CreatedAt = expenseToAdd.CreatedAt,
            UpdatedAt = expenseToAdd.UpdatedAt,
            UpdatedBy = expenseToAdd.UpdatedBy,
            PaymentMethod = expenseToAdd.PaymentMethod,
            ExpenseGroup = new ExpenseGroupSummary(expenseGroup.Id, expenseGroup.Name)
        };
    }
}
