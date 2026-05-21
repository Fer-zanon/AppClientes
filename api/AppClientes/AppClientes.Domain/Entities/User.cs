using System;
using System.Collections.Generic;
using System.Text;

namespace AppClientes.Domain.Entities
{
	public class User
	{
		public Guid Id { get; set; }

		public Guid BusinessId { get; set; }

		public string FullName { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public string PasswordHash { get; set; } = string.Empty;

		public string Role { get; set; } = "owner";

		public bool IsActive { get; set; } = true;

		public DateTimeOffset CreatedAt { get; set; }

		public DateTimeOffset UpdatedAt { get; set; }

		public Business Business { get; set; } = null!;

		public ICollection<Note> Notes { get; set; } = new List<Note>();

		public ICollection<Reminder> AssignedReminders { get; set; } = new List<Reminder>();
	}
}
