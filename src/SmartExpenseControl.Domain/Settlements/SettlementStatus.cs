namespace SmartExpenseControl.Domain.Settlements;

public sealed class SettlementStatus
{
    public static readonly SettlementStatus Pending = new(1, "pending");
    public static readonly SettlementStatus Processing = new(2, "processing");
    public static readonly SettlementStatus Settled = new(3, "settled");

    public int Id { get; }
    public string Name { get; }

    private SettlementStatus(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public static IEnumerable<SettlementStatus> ToList() => [Pending, Processing, Settled];

    public static SettlementStatus FromName(string name) =>
        ToList().FirstOrDefault(x => x.Name == name)
        ?? throw new ArgumentException($"Invalid SettlementStatus name: {name}");

    public static SettlementStatus FromId(int id) =>
        ToList().FirstOrDefault(x => x.Id == id)
        ?? throw new ArgumentException($"Invalid SettlementStatus id: {id}");

    public override string ToString() => Name;
}
