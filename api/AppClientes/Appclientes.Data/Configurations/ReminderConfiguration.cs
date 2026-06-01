using AppClientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppClientes.Data.Configurations;

public class ReminderConfiguration : IEntityTypeConfiguration<Reminder>
{
	public void Configure(EntityTypeBuilder<Reminder> builder)
	{
		builder.ToTable("reminders");

		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id).HasColumnName("id");
		builder.Property(x => x.BusinessId).HasColumnName("business_id");
		builder.Property(x => x.CustomerId).HasColumnName("customer_id");
		builder.Property(x => x.AssignedToUserId).HasColumnName("assigned_to_user_id");

		builder.Property(x => x.Title)
			.HasColumnName("title")
			.HasMaxLength(200)
			.IsRequired();

		builder.Property(x => x.Description)
			.HasColumnName("description");

		builder.Property(x => x.DueAt)
			.HasColumnName("due_at");

		builder.Property(x => x.Status)
			.HasColumnName("status")
			.HasMaxLength(50)
			.HasDefaultValue("pending")
			.IsRequired();

		builder.Property(x => x.CompletedAt)
			.HasColumnName("completed_at");

		builder.Property(x => x.CreatedAt).HasColumnName("created_at");
		builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");

		builder.HasIndex(x => x.BusinessId);
		builder.HasIndex(x => x.CustomerId);
		builder.HasIndex(x => x.DueAt);
		builder.HasIndex(x => x.Status);

		builder.HasOne(x => x.Business)
			.WithMany(x => x.Reminders)
			.HasForeignKey(x => x.BusinessId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(x => x.Customer)
			.WithMany(x => x.Reminders)
			.HasForeignKey(x => x.CustomerId)
			.OnDelete(DeleteBehavior.SetNull);

		builder.HasOne(x => x.AssignedToUser)
			.WithMany(x => x.AssignedReminders)
			.HasForeignKey(x => x.AssignedToUserId)
			.OnDelete(DeleteBehavior.SetNull);
	}
}