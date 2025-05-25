namespace SmartExpenseControl.Domain.Settlements;

public sealed class ExpenseSettlement
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public int ExpensePeriodSettlementId { get; private set; }
    public decimal TotalAmount { get; private set; }
    public decimal Payable { get; private set; }
    public decimal Receivable { get; private set; }
    public decimal Percentage { get; private set; }
    public SettlementStatus Status { get; private set; } = SettlementStatus.Pending;
    public ExpensePeriodSettlement ExpensePeriodSettlement { get; private set; } = null!;

    private ExpenseSettlement() { }

    public ExpenseSettlement(int userId, int expensePeriodSettlementId, decimal totalAmount, decimal payable, decimal receivable, decimal percentage)
    {
        UserId = userId;
        ExpensePeriodSettlementId = expensePeriodSettlementId;
        TotalAmount = totalAmount;
        Payable = payable;
        Receivable = receivable;
        Percentage = percentage;
    }
}
