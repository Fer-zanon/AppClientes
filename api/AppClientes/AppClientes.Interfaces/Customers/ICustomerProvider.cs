using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppClientes.Shared.Dtos.Customers;

namespace AppClientes.Interfaces.Customers
{
	public interface ICustomerProvider
	{
		Task<List<CustomerListItemDto>> GetCustomersAsync(CancellationToken cancellationToken);

		Task<CustomerDetailsDto?> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken);

		Task<CustomerDetailsDto> CreateCustomerAsync(
			CreateCustomerRequestDto request,
			CancellationToken cancellationToken);
	}
}
