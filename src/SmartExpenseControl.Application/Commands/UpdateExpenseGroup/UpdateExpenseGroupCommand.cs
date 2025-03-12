using MediatR;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Application.Commands.UpdateExpenseGroup;

public record UpdateExpenseGroupCommand : IRequest<Message<ExpenseGroup>>;
