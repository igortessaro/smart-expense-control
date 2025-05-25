using MediatR;
using SmartExpenseControl.Domain.ExpenseGroups.Models;
using SmartExpenseControl.Domain.Shared;

namespace SmartExpenseControl.Application.Expenses.Commands;

public record CreateExpenseGroupCommand() : IRequest<Notification<ExpenseGroupSummary>>
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public int CreatedBy { get; init; }
}
