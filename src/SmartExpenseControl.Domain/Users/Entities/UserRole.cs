namespace SmartExpenseControl.Domain.Users.Entities;

public sealed class UserRole
{
    private UserRole() { }

    public UserRole(string name, string description) : this()
    {
        Name = name;
        Description = description;
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public IList<User> Users { get; private set; } = [];
}
