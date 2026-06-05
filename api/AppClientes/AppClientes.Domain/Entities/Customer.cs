using System;
using System.Collections.Generic;
using System.Text;

namespace AppClientes.Domain.Entities
{
	public class Customer : BaseEntity
	{

		public Guid BusinessId { get; set; }

		public string FullName { get; set; } = string.Empty;

		public string? Phone { get; set; }

		public string? Email { get; set; }

		public string Status { get; set; } = "active";

		public string? Source { get; set; }

		public string? NotesSummary { get; set; }

		public Business Business { get; set; } = null!;

		public ICollection<Note> Notes { get; set; } = new List<Note>();

		public ICollection<Reminder> Reminders { get; set; } = new List<Reminder>();

		public ICollection<CustomerTag> CustomerTags { get; set; } = new List<CustomerTag>();
		public ICollection<Pet> Pets { get; set; } = new List<Pet>();
	}
}
