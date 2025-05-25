using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartExpenseControl.Domain.ExpenseGroups;
using SmartExpenseControl.Domain.ExpenseGroups.Entities;

namespace SmartExpenseControl.Infrastructure.Configurations;

public sealed class ExpenseTypeConfiguration : IEntityTypeConfiguration<ExpenseType>
{
    public void Configure(EntityTypeBuilder<ExpenseType> builder)
    {
        builder.ToTable("expense_types");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("description");

        builder.Property(x => x.ExpenseGroupId)
            .HasColumnName("expense_group_id")
            .IsRequired();

        builder.HasIndex(x => new { x.ExpenseGroupId, x.Name })
            .IsUnique()
            .HasDatabaseName("uq_expense_types_group_name");

        builder.HasIndex(x => x.ExpenseGroupId)
            .HasDatabaseName("idx_expense_types_expense_group_id");

        builder.HasOne(x => x.ExpenseGroup)
            .WithMany(x => x.ExpenseTypes)
            .HasForeignKey(x => x.ExpenseGroupId);
    }
}
