using AppClientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppClientes.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
	{
	}

	public DbSet<Business> Businesses => Set<Business>();
	public DbSet<User> Users => Set<User>();
	public DbSet<Customer> Customers => Set<Customer>();
	public DbSet<Note> Notes => Set<Note>();
	public DbSet<Reminder> Reminders => Set<Reminder>();
	public DbSet<Tag> Tags => Set<Tag>();
	public DbSet<CustomerTag> CustomerTags => Set<CustomerTag>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

		base.OnModelCreating(modelBuilder);
	}
}