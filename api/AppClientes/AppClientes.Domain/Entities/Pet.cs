using System;
using System.Collections.Generic;
using System.Text;

namespace AppClientes.Domain.Entities
{
	public class Pet : BaseEntity
	{
		public Guid CustomerId { get; set; }

		public string Name { get; set; } = string.Empty;

		public string? Species { get; set; } // dog, cat, etc.

		public string? Breed { get; set; }

		public string? Notes { get; set; }

		public Customer Customer { get; set; } = null!;
	}
}
