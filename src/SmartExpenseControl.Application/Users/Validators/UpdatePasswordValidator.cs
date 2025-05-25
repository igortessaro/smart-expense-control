using FluentValidation;
using SmartExpenseControl.Application.Users.Commands;
using SmartExpenseControl.Domain.Users.Repositories;

namespace SmartExpenseControl.Application.Users.Validators;

public sealed class UpdatePasswordValidator : AbstractValidator<UpdatePasswordCommand>
{
    public UpdatePasswordValidator(IUserRepository userRepository)
    {
        RuleFor(x => x.Id)
            .MustAsync(async (id, _) => await userRepository.ExistsAsync(id))
            .WithMessage("User doesn't exist");
        RuleFor(x => new { x.Id, x.NewPassword })
            .MustAsync(async (user, _) =>
            {
                var entity = await userRepository.GetAsync(user.Id);
                return entity is not null && !entity.VerifyEqualPassword(user.NewPassword);
            }).WithMessage("Password is invalid");
        RuleFor(x => new { x.Id, x.OldPassword })
            .MustAsync(async (user, _) =>
            {
                var entity = await userRepository.GetAsync(user.Id);
                return entity is not null && entity.VerifyEqualPassword(user.OldPassword);
            }).WithMessage("Password is invalid");
    }
}
