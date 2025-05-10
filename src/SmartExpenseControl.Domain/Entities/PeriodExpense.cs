namespace SmartExpenseControl.Domain.Entities;

public sealed class PeriodExpense
{
    public PeriodExpense(int periodId, int expenseGroupId, DateTime startDate, DateTime endDate)
    {
        PeriodId = periodId;
        ExpenseGroupId = expenseGroupId;
        StartDate = startDate;
        EndDate = endDate;
    }

    public int Id { get; private set; }
    public int PeriodId { get; private set; }
    public int ExpenseGroupId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public string Status { get; private set; } = "pending";

    public Period Period { get; private set; }
    public ExpenseGroup ExpenseGroup { get; private set; }
}
