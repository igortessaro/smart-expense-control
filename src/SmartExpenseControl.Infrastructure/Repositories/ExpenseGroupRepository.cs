using SmartExpenseControl.Domain.Entities;
using SmartExpenseControl.Domain.Repositories;
using SmartExpenseControl.Infrastructure.Data;

namespace SmartExpenseControl.Infrastructure.Repositories;

public sealed class ExpenseGroupRepository(ApplicationDbContext context) : BaseRepository<ExpenseGroup>(context), IExpenseGroupRepository { }
