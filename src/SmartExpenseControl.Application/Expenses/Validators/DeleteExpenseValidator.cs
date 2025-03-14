using FluentValidation;
using SmartExpenseControl.Application.Expenses.Commands;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Expenses.Validators;

public sealed class DeleteExpenseValidator : AbstractValidator<DeleteExpenseCommand>
{
    public DeleteExpenseValidator(IExpenseRepository expenseRepository)
    {
        RuleFor(x => x.Id)
            .MustAsync(async (id, _) => await expenseRepository.ExistsAsync(id))
            .WithMessage("Expense don't exist");
    }
}
