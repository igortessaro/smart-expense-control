using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartExpenseControl.Domain.ExpenseGroups;
using SmartExpenseControl.Domain.ExpenseGroups.Entities;

namespace SmartExpenseControl.Infrastructure.Configurations;

public sealed class ExpenseGroupsUsersConfiguration : IEntityTypeConfiguration<ExpenseGroupsUsers>
{
    public void Configure(EntityTypeBuilder<ExpenseGroupsUsers> builder)
    {
        builder.ToTable("expense_groups_users");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.ExpenseGroupId)
            .HasColumnName("expense_group_id")
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(x => x.CreatedBy)
            .HasColumnName("created_by")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at");

        builder.Property(x => x.UpdatedBy)
            .HasColumnName("updated_by");

        builder.HasIndex(x => new { x.ExpenseGroupId, x.UserId })
            .IsUnique()
            .HasDatabaseName("uq_expense_groups_users_group_user");

        builder.HasIndex(x => x.ExpenseGroupId)
            .HasDatabaseName("idx_expense_groups_users_expense_group_id");

        builder.HasIndex(x => x.UserId)
            .HasDatabaseName("idx_expense_groups_users_user_id");

        builder.HasOne(x => x.ExpenseGroup)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.ExpenseGroupId);
    }
}
