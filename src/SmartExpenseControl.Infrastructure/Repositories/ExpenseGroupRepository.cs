using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SmartExpenseControl.Domain.DataObjectTransfer;
using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Repositories;
using SmartExpenseControl.Infrastructure.Data;

namespace SmartExpenseControl.Infrastructure.Repositories;

public sealed class ExpenseGroupRepository(ApplicationDbContext context, IMapper mapper)
    : BaseRepository<ExpenseGroup>(context), IExpenseGroupRepository
{
    public Task<List<ExpenseGroup>> GetAllByUser(int userId) =>
        Query().Where(x => x.CreatedBy == userId).ToListAsync();

    public Task<ExpenseGroup?> GetByIdAsync(int id) => Query().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<PagedResponseOffset<ExpenseGroupSummary>> GetPagedAsync(PagedRequest pagedRequest)
    {
        var query = GetPagedQueryAsync(pagedRequest.PageNumber, pagedRequest.PageSize);
        int totalRecords = await query.CountAsync();
        var data = await query.ProjectTo<ExpenseGroupSummary>(mapper.ConfigurationProvider).ToListAsync();
        return new PagedResponseOffset<ExpenseGroupSummary>(pagedRequest.PageNumber, pagedRequest.PageSize, totalRecords, data);
    }

    public Task<bool> ExistsAsync(int id) => Query().AnyAsync(x => x.Id == id);

    public Task<bool> ExistsAsync(string name, int userId) => Query().AnyAsync(x => x.Name.Equals(name) && x.CreatedBy == userId);
}
