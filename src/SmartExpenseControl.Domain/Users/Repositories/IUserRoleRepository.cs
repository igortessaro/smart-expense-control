using SmartExpenseControl.Domain.Shared;
using SmartExpenseControl.Domain.Users.Entities;

namespace SmartExpenseControl.Domain.Users.Repositories;

public interface IUserRoleRepository : IRepository<UserRole>
{
    public Task<bool> ExistsAsync(int id);
}
