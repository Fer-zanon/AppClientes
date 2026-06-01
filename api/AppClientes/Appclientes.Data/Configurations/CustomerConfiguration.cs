using AppClientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppClientes.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
	public void Configure(EntityTypeBuilder<Customer> builder)
	{
		builder.ToTable("customers");

		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id).HasColumnName("id");
		builder.Property(x => x.BusinessId).HasColumnName("business_id");

		builder.Property(x => x.FullName)
			.HasColumnName("full_name")
			.HasMaxLength(150)
			.IsRequired();

		builder.Property(x => x.Phone)
			.HasColumnName("phone")
			.HasMaxLength(50);

		builder.Property(x => x.Email)
			.HasColumnName("email")
			.HasMaxLength(150);

		builder.Property(x => x.Status)
			.HasColumnName("status")
			.HasMaxLength(50)
			.HasDefaultValue("active")
			.IsRequired();

		builder.Property(x => x.Source)
			.HasColumnName("source")
			.HasMaxLength(50);

		builder.Property(x => x.NotesSummary)
			.HasColumnName("notes_summary");

		builder.Property(x => x.CreatedAt).HasColumnName("created_at");
		builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");

		builder.HasIndex(x => x.BusinessId);
		builder.HasIndex(x => x.FullName);
		builder.HasIndex(x => x.Phone);

		builder.HasIndex(x => new { x.BusinessId, x.Phone })
			.IsUnique();

		builder.HasOne(x => x.Business)
			.WithMany(x => x.Customers)
			.HasForeignKey(x => x.BusinessId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}