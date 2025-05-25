using FluentValidation;
using SmartExpenseControl.Application.Commands.DeleteExpenseGroup;
using SmartExpenseControl.Domain.ExpenseGroups.Repositories;

namespace SmartExpenseControl.Application.Expenses.Validators;

public sealed class DeleteExpenseGroupValidator : AbstractValidator<DeleteExpenseGroupCommand>
{
    public DeleteExpenseGroupValidator(IExpenseGroupRepository repository)
    {
        RuleFor(x => x.Id)
            .MustAsync(async (id, _) => await repository.ExistsAsync(id))
            .WithMessage("Expense group does not exist");
    }
}
