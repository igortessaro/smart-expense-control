using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Infrastructure.Configurations;

public sealed class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.ToTable("Expenses");
        builder.HasKey(x => x.Id).HasName("id");
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.PeriodExpenseId).HasColumnName("period_expenses_id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(255).IsRequired();
        builder.Property(x => x.Tag).HasColumnName("tag").HasMaxLength(100);
        builder.Property(x => x.Amount).HasColumnName("amount");
        builder.Property(x => x.PaymentMethodId).HasColumnName("payment_method_id").HasMaxLength(100);
        builder.Property(x => x.CreatedBy).HasColumnName("created_by").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
        builder.Property(x => x.UpdatedBy).HasColumnName("updated_by");
        builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
        builder.Property(x => x.PaidBy).HasColumnName("payed_by");
        builder.Property(x => x.PaidAt).HasColumnName("payed_at");
        builder.Property(x => x.DueDay).HasColumnName("due_day");
        builder.Property(x => x.ExpenseCategoryId).HasColumnName("expense_category_id").IsRequired();

        builder.HasOne(x => x.ExpenseGroup)
            .WithMany(x => x.Expenses)
            .HasForeignKey(x => x.PeriodExpenseId);
    }
}
