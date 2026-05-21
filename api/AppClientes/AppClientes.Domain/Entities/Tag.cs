using System;
using System.Collections.Generic;
using System.Text;

namespace AppClientes.Domain.Entities
{
	public class Tag
	{
		public Guid Id { get; set; }

		public Guid BusinessId { get; set; }

		public string Name { get; set; } = string.Empty;

		public string? Color { get; set; }

		public DateTimeOffset CreatedAt { get; set; }

		public DateTimeOffset UpdatedAt { get; set; }

		public Business Business { get; set; } = null!;

		public ICollection<CustomerTag> CustomerTags { get; set; } = new List<CustomerTag>();
	}
}
