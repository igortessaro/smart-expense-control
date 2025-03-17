using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Application.Users.Commands;

public record UpdateUserCommand(int Id, string Email, string Username, int RoleId) : IRequest<Message<UserSummary>>;
