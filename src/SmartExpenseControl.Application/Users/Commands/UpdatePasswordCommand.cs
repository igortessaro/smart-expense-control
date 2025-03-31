using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Application.Users.Commands;

public record UpdatePasswordCommand(int Id, string OldPassword, string NewPassword) : IRequest<Message<UserSummary>>;
