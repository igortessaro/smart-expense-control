using MediatR;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Application.Users.Commands;

public record DeleteUserCommand(int Id) : IRequest<Message>;
