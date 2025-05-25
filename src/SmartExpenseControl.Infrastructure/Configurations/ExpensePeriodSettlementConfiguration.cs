using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartExpenseControl.Domain.Settlements;

namespace SmartExpenseControl.Infrastructure.Configurations;

public sealed class ExpensePeriodSettlementConfiguration : IEntityTypeConfiguration<ExpensePeriodSettlement>
{
    public void Configure(EntityTypeBuilder<ExpensePeriodSettlement> builder)
    {
        builder.ToTable("expense_period_settlement");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.ExpensePeriodId)
            .HasColumnName("expense_period_id")
            .IsRequired();

        builder.Property(x => x.TotalAmount)
            .HasColumnName("total_amount")
            .IsRequired();

        builder.Property(x => x.Status)
            .HasColumnName("status")
            .HasConversion(
                v => v.Name,
                v => SettlementStatus.FromName(v)
            )
            .HasMaxLength(20)
            .IsRequired();

        builder.HasMany(x => x.Settlements)
            .WithOne(x => x.ExpensePeriodSettlement)
            .HasForeignKey(x => x.ExpensePeriodSettlementId);
    }
}
