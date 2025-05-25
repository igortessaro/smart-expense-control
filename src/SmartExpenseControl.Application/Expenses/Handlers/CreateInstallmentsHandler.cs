using MediatR;
using SmartExpenseControl.Application.Expenses.Commands;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Shared;

namespace SmartExpenseControl.Application.Expenses.Handlers;

public sealed class CreateInstallmentsHandler : IRequestHandler<CreateInstallmentsCommand, Notification<IReadOnlyList<ExpenseSummary>>>
{
    public Task<Notification<IReadOnlyList<ExpenseSummary>>> Handle(CreateInstallmentsCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
