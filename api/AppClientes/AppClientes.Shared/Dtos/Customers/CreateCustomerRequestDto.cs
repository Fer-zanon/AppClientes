namespace AppClientes.Shared.Dtos.Customers
{
	public class CreateCustomerRequestDto
	{
		public Guid BusinessId { get; set; }

		public string FullName { get; set; } = string.Empty;

		public string? Phone { get; set; }

		public string? Email { get; set; }

		public string? Source { get; set; }
	}
}
