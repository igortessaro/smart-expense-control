using MediatR;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Queries.GetUser;

public class GetUserQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserQuery, User?>
{
    public Task<User?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return userRepository.GetByIdAsync(request.UserId);
    }
}
