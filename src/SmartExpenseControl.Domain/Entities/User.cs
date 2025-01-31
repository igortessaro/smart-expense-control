namespace SmartExpenseControl.Domain.Entities;

public class User
{
    private User() { }

    public User(string userName, string email, string passwordHash, int roleId)
    {
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
        RoleId = roleId;
        CreatedAt = DateTime.UtcNow;
    }

    public int Id { get; private set; }
    public string UserName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public int RoleId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    // Constructor and methods
}
