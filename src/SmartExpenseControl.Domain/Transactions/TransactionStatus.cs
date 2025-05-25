namespace SmartExpenseControl.Domain.Transactions;

public sealed class TransactionStatus
{
    public static readonly TransactionStatus Pending = new(1, "pending");
    public static readonly TransactionStatus Completed = new(2, "completed");
    public static readonly TransactionStatus Failed = new(3, "failed");

    public int Id { get; private set; }
    public string Name { get; private set; }

    private TransactionStatus(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public static IReadOnlyList<TransactionStatus> ToList() => [Pending, Completed, Failed];

    public static TransactionStatus FromName(string name) =>
        ToList().FirstOrDefault(x => x.Name == name)
        ?? throw new ArgumentException($"Invalid TransactionStatus name: {name}");

    public static TransactionStatus FromId(int id) =>
        ToList().FirstOrDefault(x => x.Id == id)
        ?? throw new ArgumentException($"Invalid TransactionStatus id: {id}");

    public override string ToString() => Name;
}
