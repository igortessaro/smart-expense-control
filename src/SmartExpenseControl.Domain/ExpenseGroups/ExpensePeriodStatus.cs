namespace SmartExpenseControl.Domain.ExpenseGroups;

public sealed class ExpensePeriodStatus
{
    public static readonly ExpensePeriodStatus Pending = new(1, "pending");
    public static readonly ExpensePeriodStatus Open = new(2, "open");
    public static readonly ExpensePeriodStatus Closed = new(3, "closed");
    public static readonly ExpensePeriodStatus Locked = new(4, "locked");

    public int Id { get; }
    public string Name { get; }

    private ExpensePeriodStatus(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public static IEnumerable<ExpensePeriodStatus> ToList() => [Pending, Open, Closed, Locked];

    public static ExpensePeriodStatus FromName(string name) =>
        ToList().FirstOrDefault(x => x.Name == name)
        ?? throw new ArgumentException($"Invalid ExpensePeriodStatus name: {name}");

    public static ExpensePeriodStatus FromId(int id) =>
        ToList().FirstOrDefault(x => x.Id == id)
        ?? throw new ArgumentException($"Invalid ExpensePeriodStatus id: {id}");

    public override string ToString() => Name;
}
