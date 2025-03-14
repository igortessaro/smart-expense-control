using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Application.Expenses.Commands;

public record UpdateExpenseCommand() : IRequest<Message<ExpenseSummary>>
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Tag { get; init; } = string.Empty;
    public string Period { get; init; } = string.Empty;
    public decimal? Amount { get; init; }
    public string PaymentMethod { get; init; } = string.Empty;
    public int UpdatedBy { get; init; }
    public int? PayedBy { get; init; }
    public DateTime? PayedAt { get; init; }
}
