using MediatR;

namespace SmartExpenseControl.Application.Commands.CreateUser;

public record CreateUserCommand : IRequest<int>
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int RoleId { get; set; }
}
