using MediatR;
using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Application.Users.Queries;

public record GetAllRolesQuery : IRequest<IList<UserRole>> { }
