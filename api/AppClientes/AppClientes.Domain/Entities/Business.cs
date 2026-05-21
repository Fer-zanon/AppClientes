using System;
using System.Collections.Generic;
using System.Text;

namespace AppClientes.Domain.Entities
{
	public class Business
	{
		public Guid Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string Slug { get; set; } = string.Empty;

		public string? Phone { get; set; }

		public string? Email { get; set; }

		public DateTimeOffset CreatedAt { get; set; }

		public DateTimeOffset UpdatedAt { get; set; }

		public ICollection<User> Users { get; set; } = new List<User>();

		public ICollection<Customer> Customers { get; set; } = new List<Customer>();

		public ICollection<Note> Notes { get; set; } = new List<Note>();

		public ICollection<Reminder> Reminders { get; set; } = new List<Reminder>();

		public ICollection<Tag> Tags { get; set; } = new List<Tag>();
	}
}
