using MediatR;
using SmartExpenseControl.Application.Expenses.Commands;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Application.Expenses.Handlers;

public sealed class CreateInstallmentsHandler : IRequestHandler<CreateInstallmentsCommand, Message<IReadOnlyList<ExpenseSummary>>>
{
    public Task<Message<IReadOnlyList<ExpenseSummary>>> Handle(CreateInstallmentsCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
