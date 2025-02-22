namespace SmartExpenseControl.Domain.ValueObjects;

public class Money(decimal amount, string currency)
{
    public decimal Amount { get; private set; } = amount;
    public string Currency { get; private set; } = currency;

    // Override equality methods
}
