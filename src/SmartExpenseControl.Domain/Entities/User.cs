using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace SmartExpenseControl.Domain.Entities;

public sealed class User
{
    private User() { }

    public User(string userName, string email, string password, int roleId)
    {
        UserName = userName;
        Email = email;
        RoleId = roleId;
        CreatedAt = DateTime.UtcNow;
        _ = UpdatePassword(password);
    }

    public int Id { get; private set; }
    public string UserName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public int RoleId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public UserRole Role { get; private set; }

    public User Update(string userName, string email, int roleId)
    {
        if (!string.IsNullOrEmpty(userName)) UserName = userName;
        if (!string.IsNullOrEmpty(email)) Email = email;
        if (roleId > 0) RoleId = roleId;
        return this;
    }

    public User UpdatePassword(string password)
    {
        byte[] salt = new byte[128 / 8];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(salt);
        string hashed = Convert.ToBase64String(GenerateHash(salt, password));
        PasswordHash = $"{Convert.ToBase64String(salt)}.{hashed}";
        return this;
    }

    public bool VerifyEqualPassword(string password)
    {
        string[] parts = PasswordHash.Split('.');
        if (parts.Length != 2) return false;

        byte[] salt = Convert.FromBase64String(parts[0]);
        byte[] hash = Convert.FromBase64String(parts[1]);
        byte[] hashedPassword = GenerateHash(salt, password);

        return hash.SequenceEqual(hashedPassword);
    }

    private static byte[] GenerateHash(byte[] salt, string password)
    {
        return KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8);
    }
}
