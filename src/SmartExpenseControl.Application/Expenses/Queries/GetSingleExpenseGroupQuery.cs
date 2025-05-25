using MediatR;
using SmartExpenseControl.Domain.ExpenseGroups.Models;

namespace SmartExpenseControl.Application.Expenses.Queries;

public record GetSingleExpenseGroupQuery(int Id) : IRequest<ExpenseGroupSummary>;
