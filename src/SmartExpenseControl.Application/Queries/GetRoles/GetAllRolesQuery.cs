using MediatR;
using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Application.Queries.GetRoles;

public record GetAllRolesQuery : IRequest<IList<UserRole>> { }
