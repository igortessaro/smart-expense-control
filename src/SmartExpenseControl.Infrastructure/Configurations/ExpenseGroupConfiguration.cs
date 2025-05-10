using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartExpenseControl.Domain.Entities;

namespace SmartExpenseControl.Infrastructure.Configurations;

public sealed class ExpenseGroupConfiguration : IEntityTypeConfiguration<ExpenseGroup>
{
    public void Configure(EntityTypeBuilder<ExpenseGroup> builder)
    {
        builder.ToTable("ExpenseGroups");
        builder.HasKey(x => x.Id).HasName("id");
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(255).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasMaxLength(255);
        builder.Property(x => x.CreatedBy).HasColumnName("created_by").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
        builder.Property(x => x.UpdatedBy).HasColumnName("updated_by");
        builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");

        builder.HasMany(x => x.Expenses)
            .WithOne(x => x.ExpenseGroup)
            .HasForeignKey(x => x.PeriodExpenseId);
    }
}
