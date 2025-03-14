namespace SmartExpenseControl.Domain.Entities;

public sealed class Expense
{
    private Expense() { }

    public Expense(int expenseGroupId, string name, string tag, string period, decimal? amount, string paymentMethod,
        int createdBy)
        : this()
    {
        ExpenseGroupId = expenseGroupId;
        Name = name;
        Tag = tag;
        Period = period;
        Amount = amount;
        PaymentMethod = paymentMethod;
        CreatedBy = createdBy;
        CreatedAt = DateTime.UtcNow;
    }

    public int Id { get; private set; }
    public int ExpenseGroupId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Tag { get; private set; } = string.Empty;
    public string Period { get; private set; } = string.Empty;

    public decimal? Amount { get; private set; }

    // cash, credit cards, debit cards, bank transfers, mobile wallets, and digital payments
    public string PaymentMethod { get; private set; } = string.Empty;
    public int CreatedBy { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public int? UpdatedBy { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public int? PayedBy { get; private set; }
    public DateTime? PayedAt { get; private set; }

    public ExpenseGroup? ExpenseGroup { get; private set; }

    public Expense Pay(int? payedBy, DateTime? payedAt)
    {
        PayedAt = payedAt;
        PayedBy = payedBy;
        return this;
    }

    public Expense Updated(string name, string tag, string period, decimal? amount, string paymentMethod, int updatedBy)
    {
        if (!string.IsNullOrEmpty(name)) Name = name;
        if (!string.IsNullOrEmpty(tag)) Tag = tag;
        if (!string.IsNullOrEmpty(period)) Period = period;
        if (amount.HasValue) Amount = amount;
        if (!string.IsNullOrEmpty(paymentMethod)) PaymentMethod = paymentMethod;
        UpdatedBy = updatedBy;
        UpdatedAt = DateTime.UtcNow;
        return this;
    }
}
