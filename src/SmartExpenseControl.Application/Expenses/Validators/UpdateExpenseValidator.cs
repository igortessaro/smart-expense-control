using FluentValidation;
using SmartExpenseControl.Application.Expenses.Commands;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Expenses.Validators;

public sealed class UpdateExpenseValidator : AbstractValidator<UpdateExpenseCommand>
{
    public UpdateExpenseValidator(IExpenseRepository repository)
    {
        RuleFor(x => x.Name).MaximumLength(255).NotEmpty();
        RuleFor(x => x.Tag).MaximumLength(100);
        RuleFor(x => x.PayedAt).NotNull().When(x => x.PayedBy.HasValue);
        RuleFor(x => x.Id)
            .MustAsync(async (id, _) => await repository.ExistsAsync(id))
            .WithMessage("Expense doesn't exist");
        RuleFor(x => x.UpdatedBy).GreaterThan(0);
    }
}
