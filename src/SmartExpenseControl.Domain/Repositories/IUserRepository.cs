using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<bool> ExistsAsync(string email, string username, int? isNotUserId = null);
    Task<bool> ExistsAsync(int id);
    Task<UserSummary> GetByIdAsync(int id);
}
