using MediatR;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Notification;

namespace SmartExpenseControl.Application.Users.Queries;

public record GetAllRolesQuery : IRequest<Message<IList<UserRole>>>;
