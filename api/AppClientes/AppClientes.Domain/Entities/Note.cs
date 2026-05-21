using System;
using System.Collections.Generic;
using System.Text;

namespace AppClientes.Domain.Entities
{
	public class Note
	{
		public Guid Id { get; set; }

		public Guid BusinessId { get; set; }

		public Guid CustomerId { get; set; }

		public Guid? CreatedByUserId { get; set; }

		public string Text { get; set; } = string.Empty;

		public DateTimeOffset CreatedAt { get; set; }

		public DateTimeOffset UpdatedAt { get; set; }

		public Business Business { get; set; } = null!;

		public Customer Customer { get; set; } = null!;

		public User? CreatedByUser { get; set; }
	}
}
