using MediatR;
using SmartExpenseControl.Domain.ExpenseGroups.Models;
using SmartExpenseControl.Domain.Shared;

namespace SmartExpenseControl.Application.Expenses.Commands;

public record UpdateExpenseGroupCommand() : IRequest<Notification<ExpenseGroupSummary>>
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public int UpdatedBy { get; init; }
}
