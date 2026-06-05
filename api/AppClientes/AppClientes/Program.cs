using AppClientes.Data;
using Microsoft.EntityFrameworkCore;
using AppClientes.Interfaces.Customers;
using AppClientes.Providers.Customers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseNpgsql(
		builder.Configuration.GetConnectionString("AppClientes"));
});
builder.Services.AddScoped<ICustomerProvider, CustomerProvider>();
var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();