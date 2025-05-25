using MediatR;
using SmartExpenseControl.Domain.Shared;

namespace SmartExpenseControl.Application.Users.Commands;

public record DeleteUserCommand(int Id) : IRequest<Notification>;
