using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Application.Commands.CreateExpense;

public record CreateExpenseCommand : IRequest<MessageData<ExpenseSummary>>
{
    public int ExpenseGroupId { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Tag { get; init; } = string.Empty;
    public string PaymentMethod { get; init; } = string.Empty;
    public decimal? Amount { get; init; }
    public int CreatedBy { get; init; }
    public int? PayedBy { get; init; }
    public DateTime? PayedAt { get; init; }
}
