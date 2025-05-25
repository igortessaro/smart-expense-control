using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Shared;

namespace SmartExpenseControl.Application.Users.Queries;

public record GetSingleUserQuery(int Id) : IRequest<Notification<UserSummary>>;
