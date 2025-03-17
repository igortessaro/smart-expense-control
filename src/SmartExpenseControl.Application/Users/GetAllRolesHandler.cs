using MediatR;
using SmartExpenseControl.Application.Users.Queries;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Users;

public class GetAllRolesHandler(IUserRoleRepository userRoleRepository) : IRequestHandler<GetAllRolesQuery, IList<UserRole>>
{
    public Task<IList<UserRole>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken) => userRoleRepository.GetAllAsync();
}
