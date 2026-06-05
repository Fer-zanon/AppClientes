using AppClientes.Data;
using AppClientes.Interfaces.Customers;
using AppClientes.Shared.Dtos.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppClientes.WebAPI.Controllers;

[ApiController]
[Route("customers")]
public class CustomersController : ControllerBase
{
	private readonly ICustomerProvider _customerProvider;

	public CustomersController(ICustomerProvider customerProvider)
	{
		_customerProvider = customerProvider;
	}

	[HttpGet]
	public async Task<ActionResult<List<CustomerListItemDto>>> GetCustomers(
		CancellationToken cancellationToken)
	{
		var customers = await _customerProvider.GetCustomersAsync(cancellationToken);

		return Ok(customers);
	}

	[HttpGet("{id:guid}")]
	public async Task<ActionResult<CustomerDetailsDto>> GetCustomerById(
		Guid id,
		CancellationToken cancellationToken)
	{
		var customer = await _customerProvider.GetCustomerByIdAsync(id, cancellationToken);

		if (customer is null)
		{
			return NotFound();
		}

		return Ok(customer);
	}

	[HttpPost]
	[ProducesResponseType(typeof(CustomerDetailsDto), StatusCodes.Status201Created)]
	[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
	[ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
	public async Task<ActionResult<CustomerDetailsDto>> CreateCustomer(
		CreateCustomerRequestDto request,
		CancellationToken cancellationToken)
	{
		try
		{
			var customer = await _customerProvider.CreateCustomerAsync(
				request,
				cancellationToken);

			return CreatedAtAction(
				nameof(GetCustomerById),
				new { id = customer.Id },
				customer);
		}
		catch (ArgumentException exception)
		{
			return BadRequest(exception.Message);
		}
		catch (InvalidOperationException exception)
		{
			return Conflict(exception.Message);
		}
	}


}