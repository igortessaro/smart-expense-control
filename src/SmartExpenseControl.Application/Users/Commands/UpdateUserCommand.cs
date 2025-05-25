using MediatR;
using SmartExpenseControl.Domain.Shared;
using SmartExpenseControl.Domain.Users.Models;

namespace SmartExpenseControl.Application.Users.Commands;

public record UpdateUserCommand(int Id, string Email, string Username, int RoleId) : IRequest<Notification<UserSummary>>;
