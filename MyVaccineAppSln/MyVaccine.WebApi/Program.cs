using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyVaccineAppDbContext>(options =>
    options.UseSqlServer("Server=localhost,1433;Database=MyVaccineAppDb;User Id=sa;Password=Malejo07_;TrustServerCertificate=True;"/*Environment.GetEnvironmentVariable("MyVaccineDbConnectionString"))*/));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
