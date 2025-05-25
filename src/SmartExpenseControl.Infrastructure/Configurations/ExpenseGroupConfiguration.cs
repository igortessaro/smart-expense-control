using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartExpenseControl.Domain.ExpenseGroups;
using SmartExpenseControl.Domain.ExpenseGroups.ValueObjects;

namespace SmartExpenseControl.Infrastructure.Configurations;

public sealed class ExpenseGroupConfiguration : IEntityTypeConfiguration<ExpenseGroup>
{
    public void Configure(EntityTypeBuilder<ExpenseGroup> builder)
    {
        builder.ToTable("expense_groups");
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

        builder.Property(x => x.Periodicity)
            .HasColumnName("periodicity")
            .HasConversion(
                v => v.Name,
                v => Periodicity.FromName(v)
            )
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.CreatedBy)
            .HasColumnName("created_by")
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(x => x.UpdatedBy)
            .HasColumnName("updated_by");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasIndex(x => x.Name)
            .IsUnique()
            .HasDatabaseName("uq_expense_groups_name");

        builder.HasIndex(x => x.CreatedBy)
            .HasDatabaseName("idx_expense_groups_created_by");

        builder.HasIndex(x => x.UpdatedBy)
            .HasDatabaseName("idx_expense_groups_updated_by");
    }
}
