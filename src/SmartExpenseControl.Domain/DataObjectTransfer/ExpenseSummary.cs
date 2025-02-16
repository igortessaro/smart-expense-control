namespace SmartExpenseControl.Domain.DataObjectTransfer;

public record ExpenseSummary
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Tag { get; init; } = string.Empty;
    public decimal? Amount { get; init; }
    public string PaymentMethod { get; init; } = string.Empty;
    public string Period { get; init; } = string.Empty;
    public int CreatedBy { get; init; }
    public DateTime CreatedAt { get; init; }
    public int? UpdatedBy { get; init; }
    public DateTime? UpdatedAt { get; init; }
    public int? PayedBy { get; init; }
    public DateTime? PayedAt { get; init; }
    public required ExpenseGroupSummary ExpenseGroup { get; init; }
}

public record ExpenseGroupSummary(int Id, string Name);
