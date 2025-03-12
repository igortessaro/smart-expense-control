using MediatR;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Application.Commands.UpdateUser;

public record UpdateUserCommand(int Id, string Email, string Username, int RoleId) : IRequest<Message<User>>;
