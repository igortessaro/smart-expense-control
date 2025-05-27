using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SmartExpenseControl.Domain.Users;
using SmartExpenseControl.Domain.Users.Models;
using SmartExpenseControl.Domain.Users.Repositories;
using SmartExpenseControl.Infrastructure.Data;

namespace SmartExpenseControl.Infrastructure.Repositories;

public sealed class UserRepository(ApplicationDbContext context, IMapper mapper) : BaseRepository<User>(context), IUserRepository
{
    public Task<bool> ExistsAsync(string email, string username, int? isNotUserId = null)
    {
        var query = Query();
        if (!string.IsNullOrEmpty(email)) query = query.Where(u => u.Email == email);
        if (!string.IsNullOrEmpty(username)) query = query.Where(u => u.UserName == username);
        if (isNotUserId.HasValue) query = query.Where(x => x.Id != isNotUserId.Value);

        return query.AnyAsync();
    }

    public Task<bool> ExistsAsync(int id) => Query().AnyAsync(x => x.Id == id);

    public Task<bool> ExistsAsync(IReadOnlyList<int> ids) => Query().AllAsync(x => ids.Contains(x.Id));

    public Task<UserSummary> GetByIdAsync(int id) => Query()
        .Include(x => x.Role)
        .Where(x => x.Id == id)
        .ProjectTo<UserSummary>(mapper.ConfigurationProvider)
        .FirstAsync();
}
