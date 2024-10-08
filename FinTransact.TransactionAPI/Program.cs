using FinTransact.TransactionAPI.Data;
using FinTransact.TransactionAPI.ExceptionHandler.Middleware;
using FinTransact.TransactionAPI.Helpers;
using FinTransact.TransactionAPI.Interfaces;
using FinTransact.TransactionAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TransactionAPIDatabase"));
});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfiles));

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>(); //Custom Middleware

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
