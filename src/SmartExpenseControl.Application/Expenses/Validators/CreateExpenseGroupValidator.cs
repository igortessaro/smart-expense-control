using FluentValidation;
using SmartExpenseControl.Application.Expenses.Commands;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Expenses.Validators;

public sealed class CreateExpenseGroupValidator : AbstractValidator<CreateExpenseGroupCommand>
{
    public CreateExpenseGroupValidator(IExpenseGroupRepository expenseGroupRepository, IUserRepository userRepository)
    {
        RuleFor(x => x.Name).MaximumLength(255).NotEmpty();
        RuleFor(x => x.Description).MaximumLength(255).NotEmpty();
        RuleFor(x => x.CreatedBy)
            .MustAsync(async (id, _) => await userRepository.ExistsAsync(id))
            .WithMessage("User doesn't exist");
        RuleFor(x => new { GroupName = x.Name, UserId = x.CreatedBy })
            .Must(x => !expenseGroupRepository.ExistsAsync(x.GroupName, x.UserId).GetAwaiter().GetResult())
            .WithMessage("Group already exists");
    }
}
