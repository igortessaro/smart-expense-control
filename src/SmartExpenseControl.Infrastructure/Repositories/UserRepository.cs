using Microsoft.EntityFrameworkCore;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Repositories;
using SmartExpenseControl.Infrastructure.Data;

namespace SmartExpenseControl.Infrastructure.Repositories;

public sealed class UserRepository(ApplicationDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public Task<bool> ExistsAsync(string email, string username)
    {
        var query = Query();
        if (!string.IsNullOrEmpty(email)) query = query.Where(u => u.Email == email);
        if (!string.IsNullOrEmpty(username)) query = query.Where(u => u.UserName == username);

        return query.AnyAsync();
    }
}
