using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartExpenseControl.Domain.ExpenseGroups;

namespace SmartExpenseControl.Infrastructure.Configurations;

public sealed class ExpenseApportionmentConfiguration : IEntityTypeConfiguration<ExpenseApportionment>
{
    public void Configure(EntityTypeBuilder<ExpenseApportionment> builder)
    {
        builder.ToTable("expense_apportionments");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(x => x.ExpenseGroupId)
            .HasColumnName("expense_group_id")
            .IsRequired();

        builder.Property(x => x.Percentage)
            .HasColumnName("percentage")
            .IsRequired();

        builder.HasIndex(x => new { x.ExpenseGroupId, x.UserId })
            .IsUnique()
            .HasDatabaseName("uq_expense_apportionments_group_user");

        builder.HasIndex(x => x.ExpenseGroupId)
            .HasDatabaseName("idx_expense_apportionments_expense_group_id");

        builder.HasIndex(x => x.UserId)
            .HasDatabaseName("idx_expense_apportionments_user_id");

        builder.HasOne(x => x.ExpenseGroup)
            .WithMany(x => x.ExpensesApportionment)
            .HasForeignKey(x => x.ExpenseGroupId);
    }
}
