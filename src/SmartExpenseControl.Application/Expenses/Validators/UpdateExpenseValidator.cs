using FluentValidation;
using SmartExpenseControl.Application.Expenses.Commands;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Expenses.Validators;

public sealed class UpdateExpenseValidator : AbstractValidator<UpdateExpenseCommand>
{
    public UpdateExpenseValidator(IExpenseRepository expenseRepository)
    {
        RuleFor(x => x.Name).MaximumLength(255).NotEmpty();
        RuleFor(x => x.Period).Matches("^[0-9]*$").Length(6);
        RuleFor(x => x.Tag).MaximumLength(100);
        RuleFor(x => x.PaymentMethod).MaximumLength(100);
        RuleFor(x => x.PayedAt).NotNull().When(x => x.PayedBy.HasValue);
        RuleFor(x => x.Id)
            .MustAsync(async (id, _) => await expenseRepository.ExistsAsync(id))
            .WithMessage("Expense don't exist");
        RuleFor(x => x.UpdatedBy).GreaterThan(0);
    }
}
