using MediatR;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Application.Expenses.Commands;

public record DeleteExpenseCommand(int Id) : IRequest<Message>;
