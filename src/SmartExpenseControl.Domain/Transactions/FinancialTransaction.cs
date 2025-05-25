namespace SmartExpenseControl.Domain.Transactions;

public sealed class FinancialTransaction
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public int CounterpartId { get; private set; }
    public decimal Amount { get; set; }
    public string TransactionType { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
    public string Status { get; set; } = string.Empty;
    public int ExpenseSettlementId { get; private set; }
}
