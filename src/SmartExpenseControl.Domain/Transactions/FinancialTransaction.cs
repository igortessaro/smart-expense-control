namespace SmartExpenseControl.Domain.Transactions;

public sealed class FinancialTransaction
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public int CounterpartId { get; private set; }
    public decimal Amount { get; private set; }
    public TransactionType TransactionType { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }
    public TransactionStatus Status { get; private set; } = TransactionStatus.Pending;
    public int ExpenseSettlementId { get; private set; }

    private FinancialTransaction() { }

    public FinancialTransaction(
        int userId,
        int counterpartId,
        decimal amount,
        TransactionType transactionType,
        int expenseSettlementId)
    {
        UserId = userId;
        CounterpartId = counterpartId;
        Amount = amount;
        TransactionType = transactionType;
        Status = TransactionStatus.Pending;
        ExpenseSettlementId = expenseSettlementId;
        CreatedAt = DateTime.UtcNow;
    }
}
