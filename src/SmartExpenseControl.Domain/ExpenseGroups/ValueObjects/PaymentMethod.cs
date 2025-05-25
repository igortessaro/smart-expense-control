namespace SmartExpenseControl.Domain.ExpenseGroups.ValueObjects;

public sealed class PaymentMethod
{
    public static readonly PaymentMethod Pix = new(1, "pix");
    public static readonly PaymentMethod CreditCard = new(2, "credit card");
    public static readonly PaymentMethod DebitCard = new(3, "debit card");
    public static readonly PaymentMethod Cash = new(4, "cash");
    public static readonly PaymentMethod BankTransfer = new(5, "bank transfer");
    public static readonly PaymentMethod Boleto = new(6, "boleto");

    public int Id { get; }
    public string Name { get; }

    private PaymentMethod(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public static IEnumerable<PaymentMethod> ToList() => [Pix, CreditCard, DebitCard, Cash, BankTransfer, Boleto];

    public static PaymentMethod FromName(string name) =>
        ToList().FirstOrDefault(x => x.Name == name)
        ?? throw new ArgumentException($"Invalid PaymentMethod name: {name}");

    public static PaymentMethod FromId(int id) =>
        ToList().FirstOrDefault(x => x.Id == id)
        ?? throw new ArgumentException($"Invalid PaymentMethod id: {id}");

    public override string ToString() => Name;
}
