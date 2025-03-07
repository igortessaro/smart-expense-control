using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Domain.Repositories;

public interface IUserRoleRepository : IRepository<UserRole>
{
    public Task<bool> ExistsAsync(int id);
}
