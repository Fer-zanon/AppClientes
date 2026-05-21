using System;
using System.Collections.Generic;
using System.Text;

namespace AppClientes.Domain.Entities
{
	public class Reminder
	{
		public Guid Id { get; set; }

		public Guid BusinessId { get; set; }

		public Guid? CustomerId { get; set; }

		public Guid? AssignedToUserId { get; set; }

		public string Title { get; set; } = string.Empty;

		public string? Description { get; set; }

		public DateTimeOffset DueAt { get; set; }

		public string Status { get; set; } = "pending";

		public DateTimeOffset? CompletedAt { get; set; }

		public DateTimeOffset CreatedAt { get; set; }

		public DateTimeOffset UpdatedAt { get; set; }

		public Business Business { get; set; } = null!;

		public Customer? Customer { get; set; }

		public User? AssignedToUser { get; set; }
	}
}
