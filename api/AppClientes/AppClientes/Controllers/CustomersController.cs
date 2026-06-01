using AppClientes.Data;
using AppClientes.WebAPI.Dtos.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppClientes.WebAPI.Controllers;

[ApiController]
[Route("customers")]
public class CustomersController : ControllerBase
{
	private readonly AppDbContext _dbContext;

	public CustomersController(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	[HttpGet]
	public async Task<ActionResult<List<CustomerListItemDto>>> GetCustomers(
		CancellationToken cancellationToken)
	{
		var customers = await _dbContext.Customers
			.AsNoTracking()
			.OrderBy(x => x.FullName)
			.Select(x => new CustomerListItemDto
			{
				Id = x.Id,
				FullName = x.FullName,
				Phone = x.Phone,
				Email = x.Email,
				Status = x.Status,
				Source = x.Source
			})
			.ToListAsync(cancellationToken);

		return Ok(customers);
	}
}