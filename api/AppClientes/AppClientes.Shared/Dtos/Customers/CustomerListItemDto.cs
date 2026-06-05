namespace AppClientes.Shared.Dtos.Customers;

public class CustomerListItemDto
{
	public Guid Id { get; set; }

	public string FullName { get; set; } = string.Empty;

	public string? Phone { get; set; }

	public string? Email { get; set; }

	public string Status { get; set; } = string.Empty;

	public string? Source { get; set; }
}