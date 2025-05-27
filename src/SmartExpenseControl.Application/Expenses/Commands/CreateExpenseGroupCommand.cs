using MediatR;
using SmartExpenseControl.Domain.ExpenseGroups.Models;
using SmartExpenseControl.Domain.Shared;

namespace SmartExpenseControl.Application.Expenses.Commands;

public record CreateExpenseGroupCommand(
    string Name,
    string Description,
    string Periodicity,
    int CreatedBy,
    IReadOnlyList<int> Users,
    IReadOnlyList<CreateExpenseType> ExpenseTypes)
    : IRequest<Notification<ExpenseGroupSummary>>;

public record CreateExpenseType(string Name, decimal? Limit);
