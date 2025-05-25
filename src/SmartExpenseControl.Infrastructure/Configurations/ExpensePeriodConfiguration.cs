using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartExpenseControl.Domain.ExpenseGroups;

namespace SmartExpenseControl.Infrastructure.Configurations;

public sealed class ExpensePeriodConfiguration : IEntityTypeConfiguration<ExpensePeriod>
{
    public void Configure(EntityTypeBuilder<ExpensePeriod> builder)
    {
        builder.ToTable("expense_periods");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasColumnName("status")
            .HasConversion(
                v => v.Name,
                v => ExpensePeriodStatus.FromName(v)
            )
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.StartDate)
            .HasColumnName("start_date")
            .IsRequired();

        builder.Property(x => x.EndDate)
            .HasColumnName("end_date");

        builder.Property(x => x.ExpenseGroupId)
            .HasColumnName("expense_group_id")
            .IsRequired();

        builder.HasIndex(x => new { x.ExpenseGroupId, x.Name })
            .IsUnique()
            .HasDatabaseName("uq_expense_periods_group_name");

        builder.HasIndex(x => x.ExpenseGroupId)
            .HasDatabaseName("idx_expense_periods_expense_group_id");

        builder.HasOne(x => x.ExpenseGroup)
            .WithMany(x => x.ExpensePeriods)
            .HasForeignKey(x => x.ExpenseGroupId);
    }
}
