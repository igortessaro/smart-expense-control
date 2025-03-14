using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Repositories;
using SmartExpenseControl.Infrastructure.Data;

namespace SmartExpenseControl.Infrastructure.Repositories;

public sealed class ExpenseRepository(ApplicationDbContext context, IMapper mapper) : BaseRepository<Expense>(context), IExpenseRepository
{
    public async Task<PagedResponseOffset<ExpenseSummary>> GetPagedAsync(PagedRequest pagedRequest, int? userId, string period, int? expenseGroupId)
    {
        var query = Query();
        if (userId.HasValue) query = query.Where(x => x.CreatedBy == userId);
        if (!string.IsNullOrEmpty(period)) query = query.Where(x => x.Period == period);
        if (expenseGroupId.HasValue) query = query.Where(x => x.ExpenseGroupId == expenseGroupId);
        int totalRecords = await query.CountAsync();
        List<ExpenseSummary> data = await query
            .Include(x => x.ExpenseGroup)
            .OrderBy(x => x.Id)
            .Skip((pagedRequest.PageNumber - 1) * pagedRequest.PageSize)
            .Take(pagedRequest.PageSize)
            .ProjectTo<ExpenseSummary>(mapper.ConfigurationProvider)
            .ToListAsync();

        return new PagedResponseOffset<ExpenseSummary>(pagedRequest.PageNumber, pagedRequest.PageSize, totalRecords, data);
    }

    public Task<bool> ExistsAsync(int id) => Query().AnyAsync(x => x.Id == id);
}
