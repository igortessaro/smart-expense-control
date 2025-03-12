using MediatR;
using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Application.Queries.GetExpenseGroups;

public record GetSingleExpenseGroupQuery() : IRequest<ExpenseGroup>;
