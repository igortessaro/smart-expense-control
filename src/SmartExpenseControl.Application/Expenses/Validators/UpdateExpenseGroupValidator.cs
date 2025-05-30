using FluentValidation;
using SmartExpenseControl.Application.Expenses.Commands;
using SmartExpenseControl.Domain.ExpenseGroups.Repositories;
using SmartExpenseControl.Domain.Users.Repositories;

namespace SmartExpenseControl.Application.Expenses.Validators;

public sealed class UpdateExpenseGroupValidator : AbstractValidator<UpdateExpenseGroupCommand>
{
    public UpdateExpenseGroupValidator(IExpenseGroupRepository expenseGroupRepository, IUserRepository userRepository)
    {
        RuleFor(x => x.Id)
            .MustAsync(async (id, _) => await expenseGroupRepository.ExistsAsync(id))
            .WithMessage("Expense group doesn't exist");
        RuleFor(x => x.UpdatedBy)
            .MustAsync(async (id, _) => await userRepository.ExistsAsync(id))
            .WithMessage("User doesn't exist");
        RuleFor(x => x.Name).MaximumLength(255).NotEmpty();
        RuleFor(x => x.Description).MaximumLength(255).NotEmpty();
    }
}
