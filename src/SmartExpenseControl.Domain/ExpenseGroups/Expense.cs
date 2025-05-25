namespace SmartExpenseControl.Domain.ExpenseGroups;

public sealed class Expense
{
    public int Id { get; private set; }
    public int ExpensePeriodId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public decimal? Amount { get; private set; }
    public PaymentMethod? PaymentMethod { get; private set; }
    public DateTime? DueDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public int CreatedBy { get; private set; }
    public int? UpdatedBy { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public int? PaidBy { get; private set; }
    public DateTime? PaidAt { get; private set; }
    public int? ExpenseTypeId { get; private set; }
    public ExpensePeriod ExpensePeriod { get; private set; } = null!;
    public ExpenseType? ExpenseType { get; private set; }

    private Expense() { }

    public Expense(
        int expensePeriodId,
        string name,
        decimal? amount,
        PaymentMethod? paymentMethod,
        DateTime? dueDate,
        int createdBy,
        int? expenseTypeId = null)
    {
        ExpensePeriodId = expensePeriodId;
        Name = name;
        Amount = amount;
        PaymentMethod = paymentMethod;
        DueDate = dueDate;
        CreatedBy = createdBy;
        CreatedAt = DateTime.UtcNow;
        ExpenseTypeId = expenseTypeId;
    }

    public Expense Pay(int? payedBy, DateTime? payedAt)
    {
        PaidAt = payedAt;
        PaidBy = payedBy;
        return this;
    }

    public Expense Updated(string name, int? expenseTypeId, decimal? amount, string paymentMethod, int updatedBy)
    {
        if (!string.IsNullOrEmpty(name)) Name = name;
        if (expenseTypeId.HasValue) ExpenseTypeId = expenseTypeId;
        if (amount.HasValue) Amount = amount;
        if (!string.IsNullOrEmpty(paymentMethod)) PaymentMethod = PaymentMethod.FromName(paymentMethod);
        UpdatedBy = updatedBy;
        UpdatedAt = DateTime.UtcNow;
        return this;
    }
}
