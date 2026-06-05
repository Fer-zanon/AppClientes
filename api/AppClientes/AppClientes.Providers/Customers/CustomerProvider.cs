using AppClientes.Domain.Entities;
using AppClientes.Interfaces.Customers;
using AppClientes.Shared.Dtos.Customers;
using Microsoft.EntityFrameworkCore;
using AppClientes.Data;

namespace AppClientes.Providers.Customers
{
	public class CustomerProvider : ICustomerProvider
	{
		private readonly AppDbContext _dbContext;

		public CustomerProvider(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<CustomerListItemDto>> GetCustomersAsync(
		CancellationToken cancellationToken)
		{
			return await _dbContext.Customers
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
		}

		public async Task<CustomerDetailsDto?> GetCustomerByIdAsync(
			Guid id,
			CancellationToken cancellationToken)
		{
			return await _dbContext.Customers
				.AsNoTracking()
				.Where(x => x.Id == id)
				.Select(x => new CustomerDetailsDto
				{
					Id = x.Id,
					BusinessId = x.BusinessId,
					FullName = x.FullName,
					Phone = x.Phone,
					Email = x.Email,
					Status = x.Status,
					Source = x.Source,
					CreatedAt = x.CreatedAt
				})
				.FirstOrDefaultAsync(cancellationToken);
		}

		public async Task<CustomerDetailsDto> CreateCustomerAsync(
			CreateCustomerRequestDto request,
			CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(request.FullName))
			{
				throw new ArgumentException("Full name is required.");
			}

			var businessExists = await _dbContext.Businesses
				.AnyAsync(x => x.Id == request.BusinessId, cancellationToken);

			if (!businessExists)
			{
				throw new InvalidOperationException("Business does not exist.");
			}

			var phoneAlreadyExists = !string.IsNullOrWhiteSpace(request.Phone)
				&& await _dbContext.Customers.AnyAsync(
					x => x.BusinessId == request.BusinessId && x.Phone == request.Phone,
					cancellationToken);

			if (phoneAlreadyExists)
			{
				throw new InvalidOperationException("A customer with the same phone already exists.");
			}

			var customer = new Customer
			{
				Id = Guid.NewGuid(),
				BusinessId = request.BusinessId,
				FullName = request.FullName.Trim(),
				Phone = string.IsNullOrWhiteSpace(request.Phone) ? null : request.Phone.Trim(),
				Email = string.IsNullOrWhiteSpace(request.Email) ? null : request.Email.Trim(),
				Source = string.IsNullOrWhiteSpace(request.Source) ? "manual" : request.Source.Trim(),
				Status = "active",
				CreatedAt = DateTimeOffset.UtcNow,
				UpdatedAt = DateTimeOffset.UtcNow
			};

			_dbContext.Customers.Add(customer);

			await _dbContext.SaveChangesAsync(cancellationToken);

			return new CustomerDetailsDto
			{
				Id = customer.Id,
				BusinessId = customer.BusinessId,
				FullName = customer.FullName,
				Phone = customer.Phone,
				Email = customer.Email,
				Status = customer.Status,
				Source = customer.Source,
				CreatedAt = customer.CreatedAt
			};
		}
	}
}
