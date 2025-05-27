using FluentValidation;
using SmartExpenseControl.Application.Expenses.Commands;
using SmartExpenseControl.Domain.ExpenseGroups.Repositories;
using SmartExpenseControl.Domain.ExpenseGroups.ValueObjects;
using SmartExpenseControl.Domain.Users.Repositories;

namespace SmartExpenseControl.Application.Expenses.Validators;

public sealed class CreateExpenseGroupValidator : AbstractValidator<CreateExpenseGroupCommand>
{
    public CreateExpenseGroupValidator(IExpenseGroupRepository expenseGroupRepository, IUserRepository userRepository)
    {
        RuleFor(x => x.Name).MaximumLength(255).NotEmpty();
        RuleFor(x => x.Description).MaximumLength(255).NotEmpty();
        RuleFor(x => x.Periodicity)
            .NotEmpty()
            .Must(x => Periodicity.FromName(x, false) != null)
            .WithMessage(x => $"Invalid Periodicity name: {x.Periodicity}");
        RuleFor(x => x.CreatedBy)
            .MustAsync(async (id, _) => await userRepository.ExistsAsync(id))
            .WithMessage("User doesn't exist");
        RuleFor(x => new { GroupName = x.Name, UserId = x.CreatedBy })
            .MustAsync(async (expenseGroup, _) => !(await expenseGroupRepository.ExistsAsync(expenseGroup.GroupName, expenseGroup.UserId)))
            .WithMessage("Group already exists");
        RuleFor(x => x.Users)
            .MustAsync(async (users, _) => !users.Any() || await userRepository.ExistsAsync(users))
            .WithMessage("User doesn't exist");
        RuleForEach(x => x.ExpenseTypes).Where(x => x is not null).SetValidator(new CreateExpenseTypeValidator());
        RuleFor(x => x.ExpenseTypes)
            .Must(list => !list.Any() || list.GroupBy(x => x.Name).All(x => x.Count() == 1))
            .WithMessage("There are duplicate expense types in the list");
    }
}
