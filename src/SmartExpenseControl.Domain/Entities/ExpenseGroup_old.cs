using SmartExpenseControl.Domain.Users;

namespace SmartExpenseControl.Domain.Entities;

public sealed class ExpenseGroup_old
{
    private ExpenseGroup_old() { }

    public ExpenseGroup_old(string name, string description, int createdBy) : this()
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
    public int OwnerId { get; private set; }

    public IReadOnlyList<Expense_old> Expenses { get; private set; } = [];
    // public IReadOnlyList<ExpenseGroupUser> ExpenseGroupUsers { get; private set; } = [];
    public User Owner { get; private set; } = null!;

    public static ExpenseGroup_old CreateDefault(int createdBy)
    {
        return new ExpenseGroup_old("Default Expense Group", "Default Expense Group created automatically", createdBy);
    }

    public ExpenseGroup_old Update(string name, string description, int updatedBy)
    {
        if (!string.IsNullOrEmpty(name)) Name = name;
        if (!string.IsNullOrEmpty(description)) Description = description;
        UpdatedBy = updatedBy;
        UpdatedAt = DateTime.UtcNow;
        return this;
    }
}
