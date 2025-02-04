using Microsoft.Data.SqlClient;
using System.Data;
using TestProject.Repositories.Interfaces;
using TestProject.Repositories;

var builder = WebApplication.CreateBuilder(args);

// µù¥U DB ³s½u
builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnectionString")));

// µù¥U Repository
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
