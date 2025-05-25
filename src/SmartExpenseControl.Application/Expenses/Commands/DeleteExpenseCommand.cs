using MediatR;
using SmartExpenseControl.Domain.Shared;

namespace SmartExpenseControl.Application.Expenses.Commands;

public record DeleteExpenseCommand(int Id) : IRequest<Notification>;
