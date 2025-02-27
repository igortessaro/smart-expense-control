using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<bool> ExistsAsync(string email, string username);
}
