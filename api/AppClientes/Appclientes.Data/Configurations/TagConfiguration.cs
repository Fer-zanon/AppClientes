using AppClientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppClientes.Data.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
	public void Configure(EntityTypeBuilder<Tag> builder)
	{
		builder.ToTable("tags");

		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id).HasColumnName("id");
		builder.Property(x => x.BusinessId).HasColumnName("business_id");

		builder.Property(x => x.Name)
			.HasColumnName("name")
			.HasMaxLength(80)
			.IsRequired();

		builder.Property(x => x.Color)
			.HasColumnName("color")
			.HasMaxLength(30);

		builder.Property(x => x.CreatedAt).HasColumnName("created_at");
		builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");

		builder.HasIndex(x => x.BusinessId);

		builder.HasIndex(x => new { x.BusinessId, x.Name })
			.IsUnique();

		builder.HasOne(x => x.Business)
			.WithMany(x => x.Tags)
			.HasForeignKey(x => x.BusinessId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}