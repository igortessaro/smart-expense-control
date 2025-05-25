using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartExpenseControl.Domain.Settlements;

namespace SmartExpenseControl.Infrastructure.Configurations;

public sealed class ExpenseSettlementConfiguration : IEntityTypeConfiguration<ExpenseSettlement>
{
    public void Configure(EntityTypeBuilder<ExpenseSettlement> builder)
    {
        builder.ToTable("expense_settlement");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(x => x.ExpensePeriodSettlementId)
            .HasColumnName("expense_period_settlement_id")
            .IsRequired();

        builder.Property(x => x.TotalAmount)
            .HasColumnName("total_amount")
            .IsRequired();

        builder.Property(x => x.Payable)
            .HasColumnName("payable")
            .IsRequired();

        builder.Property(x => x.Receivable)
            .HasColumnName("receivable")
            .IsRequired();

        builder.Property(x => x.Percentage)
            .HasColumnName("percentage")
            .IsRequired();

        builder.Property(x => x.Status)
            .HasColumnName("status")
            .HasConversion(
                v => v.Name,
                v => SettlementStatus.FromName(v)
            )
            .HasMaxLength(20)
            .IsRequired();

        builder.HasIndex(x => new { x.ExpensePeriodSettlementId, x.UserId })
            .IsUnique()
            .HasDatabaseName("uq_expense_settlement_user_period");
    }
}
