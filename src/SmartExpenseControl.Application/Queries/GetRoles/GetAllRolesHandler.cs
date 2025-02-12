using MediatR;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Queries.GetRoles;

public class GetAllRolesHandler(IUserRoleRepository userRoleRepository) : IRequestHandler<GetAllRolesQuery, IList<UserRole>>
{
    public Task<IList<UserRole>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken) => userRoleRepository.GetAllAsync();
}
