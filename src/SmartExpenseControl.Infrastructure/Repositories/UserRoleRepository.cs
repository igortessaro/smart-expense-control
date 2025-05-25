using Microsoft.EntityFrameworkCore;
using SmartExpenseControl.Domain.Users;
using SmartExpenseControl.Domain.Users.Entities;
using SmartExpenseControl.Domain.Users.Repositories;
using SmartExpenseControl.Infrastructure.Data;

namespace SmartExpenseControl.Infrastructure.Repositories;

public sealed class UserRoleRepository(ApplicationDbContext context)
    : BaseRepository<UserRole>(context), IUserRoleRepository
{
    public Task<bool> ExistsAsync(int id) => Query().AnyAsync(x => x.Id == id);
}
