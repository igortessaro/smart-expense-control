namespace SmartExpenseControl.Domain.ExpenseGroups;

public sealed class ExpensePeriod
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public ExpensePeriodStatus Status { get; private set; } = null!;
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public int ExpenseGroupId { get; private set; }
    public ExpenseGroup ExpenseGroup { get; private set; } = null!;
    public IReadOnlyList<Expense> Expenses { get; private set; } = [];

    private ExpensePeriod() { }

    public ExpensePeriod(string name, ExpensePeriodStatus status, DateTime startDate, DateTime? endDate, int expenseGroupId)
    {
        Name = name;
        Status = status;
        StartDate = startDate;
        EndDate = endDate;
        ExpenseGroupId = expenseGroupId;
    }
}
