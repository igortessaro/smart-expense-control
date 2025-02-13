namespace SmartExpenseControl.Domain.Entities;

public sealed class ExpenseGroup
{
    private ExpenseGroup() { }

    public ExpenseGroup(string name, string description, int createdBy)
    {
        Name = name;
        Description = description;
        CreatedBy = createdBy;
        CreatedAt = DateTime.UtcNow;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int CreatedBy { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public int? UpdatedBy { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public IReadOnlyList<Expense> Expenses { get; private set; }
}
