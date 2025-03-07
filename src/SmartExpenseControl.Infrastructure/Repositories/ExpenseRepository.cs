using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Repositories;
using SmartExpenseControl.Infrastructure.Data;

namespace SmartExpenseControl.Infrastructure.Repositories;

public class ExpenseRepository(ApplicationDbContext context, IMapper mapper) : BaseRepository<Expense>(context), IExpenseRepository
{
    public async Task<PagedResponseOffset<ExpenseSummary>> GetByUserIdAsync(int userId, int pageNumber, int pageSize)
    {
        var query = Query().Where(e => e.CreatedBy == userId);
        var totalRecords = await query.CountAsync();
        var data = await query
            .Include(x => x.ExpenseGroup)
            .OrderBy(x => x.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ProjectTo<ExpenseSummary>(mapper.ConfigurationProvider)
            .ToListAsync();

        return new PagedResponseOffset<ExpenseSummary>(pageNumber, pageSize, totalRecords, data);
    }
}
