using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Shared;

namespace SmartExpenseControl.Application.Expenses.Commands;

public record UpdateExpenseCommand() : IRequest<Notification<ExpenseSummary>>
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Tag { get; init; } = string.Empty;
    public decimal? Amount { get; init; }
    public int? PaymentMethodId { get; init; }
    public int UpdatedBy { get; init; }
    public int? PayedBy { get; init; }
    public DateTime? PayedAt { get; init; }
}
