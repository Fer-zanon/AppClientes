using AppClientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppClientes.Data.Configurations;

public class CustomerTagConfiguration : IEntityTypeConfiguration<CustomerTag>
{
	public void Configure(EntityTypeBuilder<CustomerTag> builder)
	{
		builder.ToTable("customer_tags");

		builder.HasKey(x => new { x.CustomerId, x.TagId });

		builder.Property(x => x.CustomerId)
			.HasColumnName("customer_id");

		builder.Property(x => x.TagId)
			.HasColumnName("tag_id");

		builder.Property(x => x.CreatedAt)
			.HasColumnName("created_at");

		builder.HasIndex(x => x.TagId);

		builder.HasOne(x => x.Customer)
			.WithMany(x => x.CustomerTags)
			.HasForeignKey(x => x.CustomerId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(x => x.Tag)
			.WithMany(x => x.CustomerTags)
			.HasForeignKey(x => x.TagId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}