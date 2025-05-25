using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartExpenseControl.Domain.Transactions;

namespace SmartExpenseControl.Infrastructure.Configurations;

public sealed class FinancialTransactionConfiguration : IEntityTypeConfiguration<FinancialTransaction>
{
    public void Configure(EntityTypeBuilder<FinancialTransaction> builder)
    {
        builder.ToTable("financial_transactions");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(x => x.UserId).HasColumnName("user_id").IsRequired();
        builder.Property(x => x.CounterpartId).HasColumnName("counterparty_id").IsRequired();
        builder.Property(x => x.Amount).HasColumnName("amount").IsRequired();
        // builder.Property(x => x.Description).HasColumnName("description");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
        builder.Property(x => x.ExpenseSettlementId).HasColumnName("expense_settlement_id").IsRequired();

        builder.Property(x => x.TransactionType)
            .HasColumnName("transaction_type")
            .HasConversion(
                v => v.Name,
                v => TransactionType.FromName(v)
            )
            .IsRequired();

        builder.Property(x => x.Status)
            .HasColumnName("status")
            .HasConversion(
                v => v.Name,
                v => TransactionStatus.FromName(v)
            )
            .IsRequired();
    }
}
