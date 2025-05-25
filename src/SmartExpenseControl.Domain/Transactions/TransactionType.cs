namespace SmartExpenseControl.Domain.Transactions;

public sealed class TransactionType
{
    public static readonly TransactionType Income = new(1, "income");
    public static readonly TransactionType Expense = new(2, "expense");

    public int Id { get; }
    public string Name { get; }

    private TransactionType(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public static IReadOnlyList<TransactionType> ToList() => [Income, Expense ];

    public static TransactionType FromName(string name) => ToList().FirstOrDefault(x => x.Name == name) ?? throw new ArgumentException($"Invalid TransactionType name: {name}");

    public static TransactionType FromId(int id) => ToList().FirstOrDefault(x => x.Id == id) ?? throw new ArgumentException($"Invalid TransactionType id: {id}");

    public override string ToString() => Name;
}
