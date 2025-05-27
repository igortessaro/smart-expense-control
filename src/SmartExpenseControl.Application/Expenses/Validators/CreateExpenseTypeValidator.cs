using FluentValidation;
using SmartExpenseControl.Application.Expenses.Commands;

namespace SmartExpenseControl.Application.Expenses.Validators;

public sealed class CreateExpenseTypeValidator : AbstractValidator<CreateExpenseTypeCommand>
{
    public CreateExpenseTypeValidator()
    {
        RuleFor(x => x.Name).MaximumLength(255).NotEmpty();
        RuleFor(x => x.Limit)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Limit must be greater than or equal to zero.")
            .When(x => x.Limit.HasValue);
    }
}
