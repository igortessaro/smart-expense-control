using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Application.Users.Queries;

public record GetSingleUserQuery(int Id) : IRequest<Message<UserSummary>>;
