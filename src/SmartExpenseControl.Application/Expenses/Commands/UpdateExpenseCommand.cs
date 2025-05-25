using MediatR;
using SmartExpenseControl.Domain.ExpenseGroups.Models;
using SmartExpenseControl.Domain.Shared;

namespace SmartExpenseControl.Application.Expenses.Commands;

public record UpdateExpenseCommand() : IRequest<Notification<ExpenseSummary>>
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int? ExpenseTypeId { get; init; }
    public decimal? Amount { get; init; }
    public string PaymentMethod { get; init; } = string.Empty;
    public int UpdatedBy { get; init; }
    public int? PayedBy { get; init; }
    public DateTime? PayedAt { get; init; }
}
