using FluentValidation;
using SmartExpenseControl.Application.Users.Commands;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Users.Validators;

public sealed class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserValidator(IUserRepository userRepository, IUserRoleRepository userRoleRepository)
    {
        RuleFor(x => x.Id)
            .MustAsync(async (id, _) => await userRepository.ExistsAsync(id))
            .WithMessage("User doesn't exist");
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => new { x.Email, x.Id })
            .MustAsync(async (user, _) => !await userRepository.ExistsAsync(user.Email, string.Empty, user.Id))
            .WithMessage("Email address is already in use");
        RuleFor(x => new { x.Username, x.Id })
            .MustAsync(async (user, _) => !await userRepository.ExistsAsync(string.Empty, user.Username, user.Id))
            .WithMessage("User name is already in use");
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.RoleId)
            .MustAsync(async (roleId, _) => await userRoleRepository.ExistsAsync(roleId))
            .WithMessage("Role doesn't exist");
    }
}
