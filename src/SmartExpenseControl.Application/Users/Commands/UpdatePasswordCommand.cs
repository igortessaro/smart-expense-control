using MediatR;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Application.Users.Commands;

public record UpdatePasswordCommand(int Id, string OldPassword, string NewPassword) : IRequest<Message<User>>;
