namespace SmartExpenseControl.Domain.Entities;

public sealed class ExpenseGroup
{
    private ExpenseGroup() { }

    public ExpenseGroup(string name, string description, int createdBy) : this()
    {
        Name = name;
        Description = description;
        CreatedBy = createdBy;
        CreatedAt = DateTime.UtcNow;
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public int CreatedBy { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public int? UpdatedBy { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public IReadOnlyList<Expense> Expenses { get; private set; } = [];

    public static ExpenseGroup CreateDefault(int createdBy)
    {
        return new ExpenseGroup("Default Expense Group", "Default Expense Group created automatically", createdBy);
    }
}
