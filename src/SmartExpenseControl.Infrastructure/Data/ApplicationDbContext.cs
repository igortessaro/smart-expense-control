using Microsoft.EntityFrameworkCore;
using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Budget> Budgets { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<ExpenseCategory> ExpenseCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configure entity relationships and constraints here
    }
}