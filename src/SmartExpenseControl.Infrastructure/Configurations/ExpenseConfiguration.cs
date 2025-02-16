using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Infrastructure.Configurations;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.ToTable("Expenses");
        builder.HasKey(x => x.Id).HasName("id");
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.ExpenseGroupId).HasColumnName("expense_group_id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(255).IsRequired();
        builder.Property(x => x.Tag).HasColumnName("tag").HasMaxLength(100);
        builder.Property(x => x.Period).HasColumnName("period").HasMaxLength(6).IsRequired();
        builder.Property(x => x.Amount).HasColumnName("amount");
        builder.Property(x => x.PaymentMethod).HasColumnName("payment_method").HasMaxLength(100);
        builder.Property(x => x.CreatedBy).HasColumnName("created_by").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
        builder.Property(x => x.UpdatedBy).HasColumnName("updated_by");
        builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
        builder.Property(x => x.PayedBy).HasColumnName("payed_by");
        builder.Property(x => x.PayedAt).HasColumnName("payed_at");

        builder.HasOne(x => x.ExpenseGroup)
            .WithMany(x => x.Expenses)
            .HasForeignKey(x => x.ExpenseGroupId);
    }
}
