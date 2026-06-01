using AppClientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppClientes.Data.Configurations;

public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
	public void Configure(EntityTypeBuilder<Note> builder)
	{
		builder.ToTable("notes");

		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id).HasColumnName("id");
		builder.Property(x => x.BusinessId).HasColumnName("business_id");
		builder.Property(x => x.CustomerId).HasColumnName("customer_id");
		builder.Property(x => x.CreatedByUserId).HasColumnName("created_by_user_id");

		builder.Property(x => x.Text)
			.HasColumnName("text")
			.IsRequired();

		builder.Property(x => x.CreatedAt).HasColumnName("created_at");
		builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");

		builder.HasIndex(x => x.BusinessId);
		builder.HasIndex(x => x.CustomerId);

		builder.HasOne(x => x.Business)
			.WithMany(x => x.Notes)
			.HasForeignKey(x => x.BusinessId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(x => x.Customer)
			.WithMany(x => x.Notes)
			.HasForeignKey(x => x.CustomerId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(x => x.CreatedByUser)
			.WithMany(x => x.Notes)
			.HasForeignKey(x => x.CreatedByUserId)
			.OnDelete(DeleteBehavior.SetNull);
	}
}