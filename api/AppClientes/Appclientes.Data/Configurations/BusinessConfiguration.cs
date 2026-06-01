using AppClientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppClientes.Data.Configurations;

public class BusinessConfiguration : IEntityTypeConfiguration<Business>
{
	public void Configure(EntityTypeBuilder<Business> builder)
	{
		builder.ToTable("businesses");

		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id)
			.HasColumnName("id");

		builder.Property(x => x.Name)
			.HasColumnName("name")
			.HasMaxLength(150)
			.IsRequired();

		builder.Property(x => x.Slug)
			.HasColumnName("slug")
			.HasMaxLength(120)
			.IsRequired();

		builder.Property(x => x.Phone)
			.HasColumnName("phone")
			.HasMaxLength(50);

		builder.Property(x => x.Email)
			.HasColumnName("email")
			.HasMaxLength(150);

		builder.Property(x => x.CreatedAt)
			.HasColumnName("created_at");

		builder.Property(x => x.UpdatedAt)
			.HasColumnName("updated_at");

		builder.HasIndex(x => x.Slug)
			.IsUnique();
	}
}