using MediatR;
using SmartExpenseControl.Application.Users.Commands;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Notification;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Users;

public sealed class CreateUserHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, Message<User>>
{
    public async Task<Message<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Username, request.Email, HashPassword(request.Password), request.RoleId);
        await userRepository.AddAsync(user);
        return user;
    }

    private string HashPassword(string password)
    {
        // Implement password hashing logic here
        return password; // Placeholder
    }
}
