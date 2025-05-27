namespace SmartExpenseControl.Domain.ExpenseGroups.ValueObjects;

public sealed class Periodicity
{
    public static readonly Periodicity Daily = new(1, "daily");
    public static readonly Periodicity Weekly = new(2, "weekly");
    public static readonly Periodicity BiWeekly = new(3, "bi-weekly");
    public static readonly Periodicity Monthly = new(4, "monthly");
    public static readonly Periodicity Yearly = new(5, "yearly");
    public static readonly Periodicity OneTime = new(6, "one-time");

    public int Id { get; }
    public string Name { get; }

    private Periodicity(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public static IEnumerable<Periodicity> ToList() => [Daily, Weekly, BiWeekly, Monthly, Yearly, OneTime];

    public static Periodicity FromName(string name) => FromName(name, true)!;

    public static Periodicity? FromName(string name, bool throwException)
    {
        var result = ToList().FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (result is not null || !throwException) return result;
        throw new ArgumentException($"Invalid Periodicity name: {name}");
    }

    public static Periodicity FromId(int id) =>
        ToList().FirstOrDefault(x => x.Id == id)
        ?? throw new ArgumentException($"Invalid Periodicity id: {id}");

    public override string ToString() => Name;
}
