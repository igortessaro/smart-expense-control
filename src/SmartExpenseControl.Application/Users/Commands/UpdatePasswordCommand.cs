using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Shared;

namespace SmartExpenseControl.Application.Users.Commands;

public record UpdatePasswordCommand(int Id, string OldPassword, string NewPassword) : IRequest<Notification<UserSummary>>;
