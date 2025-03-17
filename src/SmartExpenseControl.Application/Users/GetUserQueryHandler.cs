using MediatR;
using SmartExpenseControl.Application.Users.Queries;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Users;

public class GetUserQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserQuery, User?>
{
    public Task<User?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return userRepository.GetAsync(request.UserId);
    }
}
