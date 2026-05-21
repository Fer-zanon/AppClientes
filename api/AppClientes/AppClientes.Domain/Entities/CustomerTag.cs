using System;
using System.Collections.Generic;
using System.Text;

namespace AppClientes.Domain.Entities
{
	public class CustomerTag
	{
		public Guid CustomerId { get; set; }

		public Guid TagId { get; set; }

		public DateTimeOffset CreatedAt { get; set; }

		public Customer Customer { get; set; } = null!;

		public Tag Tag { get; set; } = null!;
	}
}
