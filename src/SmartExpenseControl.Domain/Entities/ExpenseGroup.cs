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

    // TODO: Create a property to set the user owner and another property to set the users that can see this group

    public IReadOnlyList<Expense> Expenses { get; private set; } = [];

    public static ExpenseGroup CreateDefault(int createdBy)
    {
        return new ExpenseGroup("Default Expense Group", "Default Expense Group created automatically", createdBy);
    }

    public ExpenseGroup Update(string name, string description, int updatedBy)
    {
        if (!string.IsNullOrEmpty(name)) Name = name;
        if (!string.IsNullOrEmpty(description)) Description = description;
        UpdatedBy = updatedBy;
        UpdatedAt = DateTime.UtcNow;
        return this;
    }
}
