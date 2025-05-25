namespace SmartExpenseControl.Domain.ExpenseGroups;

public sealed class ExpenseGroupsUsers
{
    public int Id { get; private set; }
    public int ExpenseGroupId { get; private set; }
    public int UserId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public int CreatedBy { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public int? UpdatedBy { get; private set; }
    public ExpenseGroup ExpenseGroup { get; private set; } = null!;

    private ExpenseGroupsUsers() { }

    public ExpenseGroupsUsers(int expenseGroupId, int userId, int createdBy)
    {
        ExpenseGroupId = expenseGroupId;
        UserId = userId;
        CreatedBy = createdBy;
        CreatedAt = DateTime.UtcNow;
    }
}
