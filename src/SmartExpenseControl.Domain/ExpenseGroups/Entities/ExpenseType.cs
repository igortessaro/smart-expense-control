namespace SmartExpenseControl.Domain.ExpenseGroups.Entities;

public sealed class ExpenseType
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public decimal? Limit { get; private set; }
    public int ExpenseGroupId { get; private set; }
    public ExpenseGroup ExpenseGroup { get; private set; } = null!;

    private ExpenseType() { }

    public ExpenseType(string name, decimal? limit, int expenseGroupId)
    {
        Name = name;
        Limit = limit;
        ExpenseGroupId = expenseGroupId;
    }
}
