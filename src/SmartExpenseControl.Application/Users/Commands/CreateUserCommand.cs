using MediatR;
using SmartExpenseControl.Domain.Shared;
using SmartExpenseControl.Domain.Users.Models;

namespace SmartExpenseControl.Application.Users.Commands;

public record CreateUserCommand : IRequest<Notification<UserSummary>>
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int RoleId { get; set; }
}
