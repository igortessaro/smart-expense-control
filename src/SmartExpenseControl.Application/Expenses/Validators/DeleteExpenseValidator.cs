using FluentValidation;
using SmartExpenseControl.Application.Expenses.Commands;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Expenses.Validators;

public sealed class DeleteExpenseValidator : AbstractValidator<DeleteExpenseCommand>
{
    public DeleteExpenseValidator(IExpenseRepository repository)
    {
        RuleFor(x => x.Id)
            .MustAsync(async (id, _) => await repository.ExistsAsync(id))
            .WithMessage("Expense doesn't exist");
    }
}
