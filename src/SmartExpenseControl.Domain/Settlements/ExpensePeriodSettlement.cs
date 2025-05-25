namespace SmartExpenseControl.Domain.Settlements;

public sealed class ExpensePeriodSettlement
{
    public int Id { get; private set; }
    public int ExpensePeriodId { get; private set; }
    public decimal TotalAmount { get; private set; }
    public SettlementStatus Status { get; private set; } = SettlementStatus.Pending;
    public IReadOnlyCollection<ExpenseSettlement> Settlements { get; private set; } = [];

    private ExpensePeriodSettlement() { }

    public ExpensePeriodSettlement(int expensePeriodId, decimal totalAmount)
    {
        ExpensePeriodId = expensePeriodId;
        TotalAmount = totalAmount;
    }
}
