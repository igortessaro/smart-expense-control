using MediatR;
using SmartExpenseControl.Domain.Shared;
using SmartExpenseControl.Domain.Users.Models;

namespace SmartExpenseControl.Application.Users.Queries;

public record GetSingleUserQuery(int Id) : IRequest<Notification<UserSummary>>;
