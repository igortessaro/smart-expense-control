using SmartExpenseControl.Domain.Shared;
using SmartExpenseControl.Domain.Users;

namespace SmartExpenseControl.Domain.Repositories;

public interface IUserRoleRepository : IRepository<UserRole>
{
    public Task<bool> ExistsAsync(int id);
}
