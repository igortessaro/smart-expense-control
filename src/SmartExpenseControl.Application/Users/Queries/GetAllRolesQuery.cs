using MediatR;
using SmartExpenseControl.Domain.Shared;
using SmartExpenseControl.Domain.Users;
using SmartExpenseControl.Domain.Users.Entities;

namespace SmartExpenseControl.Application.Users.Queries;

public record GetAllRolesQuery : IRequest<Notification<IList<UserRole>>>;
