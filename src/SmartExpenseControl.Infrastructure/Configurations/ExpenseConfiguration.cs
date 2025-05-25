using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartExpenseControl.Domain.ExpenseGroups;

namespace SmartExpenseControl.Infrastructure.Configurations;

public sealed class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.ToTable("expenses");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.ExpensePeriodId)
            .HasColumnName("expense_period_id")
            .IsRequired();

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Amount)
            .HasColumnName("amount");

        builder.Property(x => x.PaymentMethod)
            .HasColumnName("payment_method")
            .HasConversion(
                v => v == null ? null : v.Name,
                v => v == null ? null : PaymentMethod.FromName(v)
            )
            .HasMaxLength(30);

        builder.Property(x => x.DueDate)
            .HasColumnName("due_date");

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(x => x.CreatedBy)
            .HasColumnName("created_by")
            .IsRequired();

        builder.Property(x => x.UpdatedBy)
            .HasColumnName("updated_by");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at");

        builder.Property(x => x.PaidBy)
            .HasColumnName("paid_by");

        builder.Property(x => x.PaidAt)
            .HasColumnName("paid_at");

        builder.Property(x => x.ExpenseTypeId)
            .HasColumnName("expense_type_id");

        builder.HasIndex(x => x.ExpensePeriodId)
            .HasDatabaseName("idx_expenses_expense_period_id");

        builder.HasIndex(x => x.CreatedBy)
            .HasDatabaseName("idx_expenses_created_by");

        builder.HasIndex(x => x.UpdatedBy)
            .HasDatabaseName("idx_expenses_updated_by");

        builder.HasIndex(x => x.PaidBy)
            .HasDatabaseName("idx_expenses_paid_by");

        builder.HasIndex(x => x.ExpenseTypeId)
            .HasDatabaseName("idx_expenses_expense_type_id");

        builder.HasOne(x => x.ExpensePeriod)
            .WithMany(x => x.Expenses)
            .HasForeignKey(x => x.ExpensePeriodId);

        builder.HasOne(x => x.ExpenseType)
            .WithMany()
            .HasForeignKey(x => x.ExpenseTypeId);
    }
}
