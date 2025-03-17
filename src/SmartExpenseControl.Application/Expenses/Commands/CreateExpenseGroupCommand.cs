using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Application.Expenses.Commands;

public record CreateExpenseGroupCommand() : IRequest<Message<ExpenseGroupSummary>>
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public int CreatedBy { get; init; }
}
