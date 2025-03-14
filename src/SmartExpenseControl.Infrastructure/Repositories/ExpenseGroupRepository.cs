using Microsoft.EntityFrameworkCore;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Repositories;
using SmartExpenseControl.Infrastructure.Data;

namespace SmartExpenseControl.Infrastructure.Repositories;

public sealed class ExpenseGroupRepository(ApplicationDbContext context)
    : BaseRepository<ExpenseGroup>(context), IExpenseGroupRepository
{
    public Task<List<ExpenseGroup>> GetAllByUser(int userId) =>
        Query().Where(x => x.CreatedBy == userId).ToListAsync();

    public Task<ExpenseGroup?> GetByIdAsync(int id) => Query().FirstOrDefaultAsync(x => x.Id == id);
}
