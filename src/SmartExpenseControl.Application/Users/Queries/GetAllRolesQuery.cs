using MediatR;
using SmartExpenseControl.Domain.Notification;
using SmartExpenseControl.Domain.Users;

namespace SmartExpenseControl.Application.Users.Queries;

public record GetAllRolesQuery : IRequest<Message<IList<UserRole>>>;
