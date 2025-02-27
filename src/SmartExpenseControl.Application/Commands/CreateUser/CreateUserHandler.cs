using MediatR;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Commands.CreateUser;

public sealed class CreateUserHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, int>
{
    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Username, request.Email, HashPassword(request.Password), request.RoleId);
        await userRepository.AddAsync(user);
        return user.Id;
    }

    private string HashPassword(string password)
    {
        // Implement password hashing logic here
        return password; // Placeholder
    }
}
