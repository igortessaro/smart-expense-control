namespace SmartExpenseControl.Domain.Entities;

public sealed class ExpenseInstallments
{
    public int Id { get; private set; }
    public int Quantity { get; private set; }
    public decimal Amount { get; private set; }
    public string FirstPeriod { get; private set; } = string.Empty;
    public string PaymentMethod { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public string Tag { get; private set; } = string.Empty;
    public int CreatedBy { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public int? UpdatedBy { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public int? PayedBy { get; private set; }
    public int DueDay { get; private set; }
    public IReadOnlyList<Expense> Expenses { get; private set; } = [];
}
