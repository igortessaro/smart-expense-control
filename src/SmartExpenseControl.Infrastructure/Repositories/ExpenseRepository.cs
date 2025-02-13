using Microsoft.EntityFrameworkCore;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Repositories;
using SmartExpenseControl.Infrastructure.Data;

namespace SmartExpenseControl.Infrastructure.Repositories;

public class ExpenseRepository(ApplicationDbContext context) : BaseRepository<Expense>(context), IExpenseRepository
{
    public async Task<IList<Expense>> GetByUserIdAsync(int userId)
    {
        return await DbSet
            .Where(e => e.CreatedBy == userId)
            .ToListAsync();
    }
}
