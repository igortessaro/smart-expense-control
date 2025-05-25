using MediatR;
using SmartExpenseControl.Domain.Shared;

namespace SmartExpenseControl.Application.Commands.DeleteExpenseGroup;

public record DeleteExpenseGroupCommand(int Id) : IRequest<Notification>;
