using FluentValidation;
using SmartExpenseControl.Application.Expenses.Commands;

namespace SmartExpenseControl.Application.Expenses.Validators;

public sealed class CreateExpenseValidator : AbstractValidator<CreateExpenseCommand>
{
    public CreateExpenseValidator()
    {
        RuleFor(x => x.Name).MaximumLength(255).NotEmpty();
        RuleFor(x => x.Period).Matches("^[0-9]*$").Length(6);
        RuleFor(x => x.Tag).MaximumLength(100);
        RuleFor(x => x.PaymentMethod).MaximumLength(100);
        RuleFor(x => x.PayedAt).NotNull().When(x => x.PayedBy.HasValue);
    }
}
