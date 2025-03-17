using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Application.Expenses.Commands;

public record UpdateExpenseGroupCommand() : IRequest<Message<ExpenseGroupSummary>>
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public int UpdatedBy { get; init; }
}
