using MediatR;
using SmartExpenseControl.Domain.Shared;
using SmartExpenseControl.Domain.Users.Models;

namespace SmartExpenseControl.Application.Users.Commands;

public record UpdatePasswordCommand(int Id, string OldPassword, string NewPassword) : IRequest<Notification<UserSummary>>;
