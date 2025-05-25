using MediatR;
using SmartExpenseControl.Domain.ExpenseGroups.Models;
using SmartExpenseControl.Domain.Shared;

namespace SmartExpenseControl.Application.Expenses.Commands;

public record CreateExpenseCommand() : IRequest<Notification<ExpenseSummary>>
{
    public int ExpenseGroupId { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Tag { get; init; } = string.Empty;
    public string Period { get; set; } = string.Empty;
    public string PaymentMethod { get; init; } = string.Empty;
    public decimal? Amount { get; init; }
    public int CreatedBy { get; init; }
    public int? PayedBy { get; init; }
    public DateTime? PayedAt { get; init; }
    public int? DueDay { get; set; }
}
