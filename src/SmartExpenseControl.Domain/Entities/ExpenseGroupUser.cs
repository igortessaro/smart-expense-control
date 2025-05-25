using SmartExpenseControl.Domain.Users;

namespace SmartExpenseControl.Domain.Entities;

public sealed class ExpenseGroupUser
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ExpenseGroupId { get; set; }
    public User User { get; private set; } = null!;
    public ExpenseGroup ExpenseGroup { get; private set; } = null!;
}
