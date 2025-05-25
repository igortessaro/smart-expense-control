using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Shared;

namespace SmartExpenseControl.Application.Expenses.Commands;

public record CreateInstallmentsCommand() : IRequest<Notification<IReadOnlyList<ExpenseSummary>>>
{
    public int Quantity { get; init; }
    public decimal Amount { get; init; }
    public string FirstPeriod { get; init; } = string.Empty;
    public string PaymentMethod { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Tag { get; init; } = string.Empty;
    public int CreatedBy { get; init; }
    public int? PayedBy { get; init; }
    public int DueDay { get; init; }
    public int ExpenseGroupId { get; init; }
}
