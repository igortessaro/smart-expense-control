using FluentValidation;
using SmartExpenseControl.Application.Users.Queries;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Users.Validators;

public class GetSingleUserValidation : AbstractValidator<GetSingleUserQuery>
{
    public GetSingleUserValidation(IUserRepository userRepository)
    {
        RuleFor(x => x.Id)
            .MustAsync(async (id, _) => await userRepository.ExistsAsync(id))
            .WithMessage("User doesn't exist");
    }
}
