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
    public IReadOnlyList<ExpenseApportionment> Apportionments { get; private set; } = [];

    private ExpenseGroup() { }

    public ExpenseGroup(string name, string? description, Periodicity periodicity, int createdBy)
    {
        Name = name;
        Description = description;
        Periodicity = periodicity;
        CreatedBy = createdBy;
        CreatedAt = DateTime.UtcNow;
    }
}
