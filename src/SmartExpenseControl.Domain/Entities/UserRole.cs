namespace SmartExpenseControl.Domain.Entities;

public sealed class UserRole
{
    private UserRole() { }

    public UserRole(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public IReadOnlyList<User> Users { get; private set; }
}
