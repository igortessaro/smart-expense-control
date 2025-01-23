namespace SmartExpenseControl.Domain.Entities;

public class Expense
{
    private Expense () { }

    public Expense(int userId, int categoryId, decimal amount, string description, DateTime date)
        : this()
    {
        UserId = userId;
        CategoryId = categoryId;
        Amount = amount;
        Date = date;
    }

    public int Id { get; private set; }
    public int UserId { get; private set; }
    public int CategoryId { get; private set; }
    public decimal Amount { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public DateTime Date { get; private set; }
}
