using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Application.Users.Commands;

public record CreateUserCommand : IRequest<Message<UserSummary>>
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int RoleId { get; set; }
}
