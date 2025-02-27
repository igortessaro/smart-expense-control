using MediatR;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Application.Commands.CreateUser;

public record CreateUserCommand : IRequest<Message<User>>
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int RoleId { get; set; }
}
