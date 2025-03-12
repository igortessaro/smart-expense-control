using MediatR;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Application.Commands.CreateExpenseGroup;

public record CreateExpenseGroupCommand() : IRequest<Message<ExpenseGroup>>;
