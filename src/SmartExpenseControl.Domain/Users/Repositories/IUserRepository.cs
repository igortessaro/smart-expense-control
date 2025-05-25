using SmartExpenseControl.Domain.Shared;
using SmartExpenseControl.Domain.Users.Models;

namespace SmartExpenseControl.Domain.Users.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<bool> ExistsAsync(string email, string username, int? isNotUserId = null);
    Task<bool> ExistsAsync(int id);
    Task<UserSummary> GetByIdAsync(int id);
}
