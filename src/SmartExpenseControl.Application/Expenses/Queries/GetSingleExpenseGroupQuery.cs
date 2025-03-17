using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;

namespace SmartExpenseControl.Application.Expenses.Queries;

public record GetSingleExpenseGroupQuery(int Id) : IRequest<ExpenseGroupSummary>;
