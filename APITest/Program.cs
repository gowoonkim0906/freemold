using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Freemold.Modules.Repositories;
using Freemold.Modules.Services;

using Microsoft.EntityFrameworkCore;

using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



// ========================================================
// ConnectionString
// ========================================================

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "DefaultConnection 연결 문자열이 없습니다."
    );

var pgConnStr =
    builder.Configuration.GetConnectionString("PostgresConnection")
    ?? throw new InvalidOperationException(
        "PostgresConnection 연결 문자열이 없습니다."
    );





// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
