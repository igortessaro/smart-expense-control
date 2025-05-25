using MediatR;
using SmartExpenseControl.Domain.Shared;
using SmartExpenseControl.Domain.Users;

namespace SmartExpenseControl.Application.Users.Queries;

public record GetAllRolesQuery : IRequest<Notification<IList<UserRole>>>;
