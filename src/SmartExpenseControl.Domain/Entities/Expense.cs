namespace SmartExpenseControl.Domain.Entities;

public sealed class Expense
{
    private Expense() { }

    public Expense(int periodExpenseId, string name, string tag, decimal? amount, int? paymentMethodId,
        int createdBy)
        : this()
    {
        PeriodExpenseId = periodExpenseId;
        Name = name;
        Tag = tag;
        Amount = amount;
        PaymentMethodId = paymentMethodId;
        CreatedBy = createdBy;
        CreatedAt = DateTime.UtcNow;
    }

    public int Id { get; private set; }
    public int PeriodExpenseId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Tag { get; private set; } = string.Empty;
    public decimal? Amount { get; private set; }
    public int? PaymentMethodId { get; private set; }
    public int CreatedBy { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public int? UpdatedBy { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public int? PaidBy { get; private set; }
    public DateTime? PaidAt { get; private set; }
    public int? DueDay { get; private set; }
    public int? ExpenseCategoryId { get; private set; }

    public PeriodExpense PeriodExpense { get; private set; } = null!;
    public ExpenseGroup? ExpenseGroup { get; private set; }
    public ExpenseCategory ExpenseCategory { get; private set; } = null!;

    public Expense Pay(int? payedBy, DateTime? payedAt)
    {
        PaidAt = payedAt;
        PaidBy = payedBy;
        return this;
    }

    public Expense Updated(string name, string tag, decimal? amount, int? paymentMethodId, int updatedBy)
    {
        if (!string.IsNullOrEmpty(name)) Name = name;
        if (!string.IsNullOrEmpty(tag)) Tag = tag;
        if (amount.HasValue) Amount = amount;
        if (paymentMethodId.HasValue) PaymentMethodId = paymentMethodId;
        UpdatedBy = updatedBy;
        UpdatedAt = DateTime.UtcNow;
        return this;
    }
}
