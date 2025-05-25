using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SmartExpenseControl.Domain.ExpenseGroups;
using SmartExpenseControl.Domain.ExpenseGroups.Entities;
using SmartExpenseControl.Domain.ExpenseGroups.Models;
using SmartExpenseControl.Domain.ExpenseGroups.Repositories;
using SmartExpenseControl.Domain.Shared;
using SmartExpenseControl.Infrastructure.Data;

namespace SmartExpenseControl.Infrastructure.Repositories;

public sealed class ExpenseRepository(ApplicationDbContext context, IMapper mapper) : BaseRepository<Expense>(context), IExpenseRepository
{
    public async Task<PagedResponseOffset<ExpenseSummary>> GetPagedAsync(PagedRequest pagedRequest, int? userId, int? periodExpenseId)
    {
        var query = Query();
        if (userId.HasValue) query = query.Where(x => x.CreatedBy == userId);
        if (periodExpenseId.HasValue) query = query.Where(x => x.ExpensePeriodId == periodExpenseId);
        int totalRecords = await query.CountAsync();
        var data = await query
            .Include(x => x.ExpensePeriod)
            .OrderBy(x => x.Id)
            .Skip((pagedRequest.PageNumber - 1) * pagedRequest.PageSize)
            .Take(pagedRequest.PageSize)
            .ProjectTo<ExpenseSummary>(mapper.ConfigurationProvider)
            .ToListAsync();

        return new PagedResponseOffset<ExpenseSummary>(pagedRequest.PageNumber, pagedRequest.PageSize, totalRecords, data);
    }

    public Task<bool> ExistsAsync(int id) => Query().AnyAsync(x => x.Id == id);
}
