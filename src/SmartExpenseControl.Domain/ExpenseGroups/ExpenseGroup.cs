namespace SmartExpenseControl.Domain.ExpenseGroups;

public sealed class ExpenseGroup
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public Periodicity Periodicity { get; private set; } = null!;
    public int CreatedBy { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public int? UpdatedBy { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public IReadOnlyList<ExpenseType> ExpenseTypes { get; private set; } = [];
    public IReadOnlyList<ExpensePeriod> ExpensePeriods { get; private set; } = [];
    public IReadOnlyList<ExpenseGroupsUsers> Users { get; private set; } = [];
    public IReadOnlyList<ExpenseApportionment> ExpensesApportionment { get; private set; } = [];

    private ExpenseGroup() { }

    public ExpenseGroup(string name, string? description, Periodicity periodicity, int createdBy)
    {
        Name = name;
        Description = description;
        Periodicity = periodicity;
        CreatedBy = createdBy;
        CreatedAt = DateTime.UtcNow;
    }

    public static ExpenseGroup CreateDefault(int createdBy)
    {
        return new ExpenseGroup("Default Expense Group", "Default Expense Group created automatically", Periodicity.OneTime, createdBy);
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
