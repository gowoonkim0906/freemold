using Freemold.Modules.Common;
using Freemold.Modules.Repositories;
using Freemold.Modules.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Tls;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Swagger 서비스 등록
builder.Services.AddEndpointsApiExplorer(); // Minimal API 용
builder.Services.AddSwaggerGen();           // Swagger 문서 생성용

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddCors(options =>
{
    // 1) 전체 오픈 (조회용 등에)
    options.AddPolicy("PublicCors", p =>
        p.AllowAnyOrigin()
         .AllowAnyHeader()
         .AllowAnyMethod());

    // 2) 일부 도메인만 허용 (메일 발송/변경 등)
    options.AddPolicy("PartnerCors", p =>
        p.WithOrigins("http://dev.freemold.net", "https://www.freemold.net")
         .AllowAnyHeader()
         .AllowAnyMethod()
    // .AllowCredentials()  // 쿠키/세션 필요할 때만. 이 경우 AllowAnyOrigin 불가
    );
});

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

app.UseRouting();      
app.UseCors();         

app.UseAuthorization();

app.MapControllers();

app.Run();


void ConfigureServices(WebApplicationBuilder builder)
{

    builder.Services.AddHttpClient();
    builder.Services.AddTransient<ISendgridService, SendgridService>();
    builder.Services.AddTransient<IBannerService, BannerService>();
    builder.Services.AddScoped<IEmailService>(provider =>
    {
        var env = provider.GetRequiredService<IWebHostEnvironment>();
        return new EmailService(env.ContentRootPath);
    });
    builder.Services.AddScoped<IFreemoldService, FreemoldService>();


    //Repository 등록
    builder.Services.AddScoped<MemberRepository>();

}
