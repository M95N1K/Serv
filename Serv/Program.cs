using Microsoft.EntityFrameworkCore;
using Serv.Data;
using Serv.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

TypeDB typeDB = TypeDB.Memory;
string connectionString;
if (typeDB == TypeDB.SQL)
    connectionString = builder.Configuration.GetConnectionString("SQL");
else 
    connectionString = "Memory";

builder.Services.AddScoped<ContextDB>(sp => new ContextDB(typeDB, connectionString));
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
