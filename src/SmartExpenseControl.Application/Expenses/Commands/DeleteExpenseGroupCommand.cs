using MediatR;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Application.Commands.DeleteExpenseGroup;

public record DeleteExpenseGroupCommand(int Id) : IRequest<Message>;
