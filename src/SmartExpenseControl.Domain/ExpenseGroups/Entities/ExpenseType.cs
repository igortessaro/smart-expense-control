namespace SmartExpenseControl.Domain.ExpenseGroups.Entities;

public sealed class ExpenseType
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public int ExpenseGroupId { get; private set; }
    public ExpenseGroup ExpenseGroup { get; private set; } = null!;

    private ExpenseType() { }

    public ExpenseType(string name, string? description, int expenseGroupId)
    {
        Name = name;
        Description = description;
        ExpenseGroupId = expenseGroupId;
    }
}
