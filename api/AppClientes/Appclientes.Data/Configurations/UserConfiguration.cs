using AppClientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppClientes.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("users");

		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id).HasColumnName("id");
		builder.Property(x => x.BusinessId).HasColumnName("business_id");

		builder.Property(x => x.FullName)
			.HasColumnName("full_name")
			.HasMaxLength(150)
			.IsRequired();

		builder.Property(x => x.Email)
			.HasColumnName("email")
			.HasMaxLength(150)
			.IsRequired();

		builder.Property(x => x.PasswordHash)
			.HasColumnName("password_hash")
			.IsRequired();

		builder.Property(x => x.Role)
			.HasColumnName("role")
			.HasMaxLength(50)
			.HasDefaultValue("owner")
			.IsRequired();

		builder.Property(x => x.IsActive)
			.HasColumnName("is_active")
			.HasDefaultValue(true);

		builder.Property(x => x.CreatedAt).HasColumnName("created_at");
		builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");

		builder.HasIndex(x => x.BusinessId);

		builder.HasIndex(x => new { x.BusinessId, x.Email })
			.IsUnique();

		builder.HasOne(x => x.Business)
			.WithMany(x => x.Users)
			.HasForeignKey(x => x.BusinessId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}