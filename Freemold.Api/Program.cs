using Freemold.Modules.Common;
using Freemold.Modules.Services;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Tls;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Swagger 서비스 등록
builder.Services.AddEndpointsApiExplorer(); // Minimal API 용
builder.Services.AddSwaggerGen();           // Swagger 문서 생성용

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<DbConn>(provider =>
{
    return new DbConn(connectionString);

});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

ConfigureServices(builder);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();                     // swagger.json 생성
    app.UseSwaggerUI();                  // Swagger UI 제공
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void ConfigureServices(WebApplicationBuilder builder)
{

    builder.Services.AddHttpClient();
    builder.Services.AddTransient<ITest, Test>();
    builder.Services.AddTransient<ISendgridService, SendgridService>();
    builder.Services.AddScoped<IEmailService>(provider =>
    {
        var env = provider.GetRequiredService<IWebHostEnvironment>();
        return new EmailService(env.ContentRootPath);
    });
    

}
