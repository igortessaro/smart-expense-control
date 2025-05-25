namespace SmartExpenseControl.Domain.ExpenseGroups.Entities;

public sealed class ExpenseApportionment
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public int ExpenseGroupId { get; private set; }
    public decimal Percentage { get; private set; }
    public ExpenseGroup ExpenseGroup { get; private set; } = null!;

    private ExpenseApportionment() { }

    public ExpenseApportionment(int userId, int expenseGroupId, decimal percentage)
    {
        UserId = userId;
        ExpenseGroupId = expenseGroupId;
        Percentage = percentage;
    }
}
