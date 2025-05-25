using Microsoft.EntityFrameworkCore;
using SmartExpenseControl.Domain.ExpenseGroups;
using SmartExpenseControl.Domain.ExpenseGroups.Entities;
using SmartExpenseControl.Domain.Settlements;
using SmartExpenseControl.Domain.Transactions;
using SmartExpenseControl.Domain.Users;
using SmartExpenseControl.Domain.Users.Entities;
using SmartExpenseControl.Infrastructure.Configurations;

namespace SmartExpenseControl.Infrastructure.Data;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<ExpenseApportionment> ExpensesApportionment { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<ExpenseGroup> ExpenseGroups { get; set; }
    public DbSet<ExpenseGroupsUsers> ExpenseGroupsUsers { get; set; }
    public DbSet<ExpensePeriod> ExpensePeriods { get; set; }
    public DbSet<ExpensePeriodSettlement> ExpensePeriodSettlements { get; set; }
    public DbSet<ExpenseSettlement> ExpenseSettlements { get; set; }
    public DbSet<ExpenseType> ExpenseTypes { get; set; }
    public DbSet<FinancialTransaction> FinancialTransactions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ExpenseApportionmentConfiguration());
        modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
        modelBuilder.ApplyConfiguration(new ExpenseGroupConfiguration());
        modelBuilder.ApplyConfiguration(new ExpenseGroupsUsersConfiguration());
        modelBuilder.ApplyConfiguration(new ExpensePeriodConfiguration());
        modelBuilder.ApplyConfiguration(new ExpensePeriodSettlementConfiguration());
        modelBuilder.ApplyConfiguration(new ExpenseSettlementConfiguration());
        modelBuilder.ApplyConfiguration(new ExpenseTypeConfiguration());
        modelBuilder.ApplyConfiguration(new FinancialTransactionConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.LogTo(Console.WriteLine).EnableSensitiveDataLogging();
}
