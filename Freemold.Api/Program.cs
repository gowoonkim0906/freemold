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


// ========================================================
// Swagger / OpenAPI
// ========================================================

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();


// ========================================================
// Controller
// ========================================================

builder.Services.AddControllers();


// ========================================================
// CORS
// ========================================================

builder.Services.AddCors(options =>
{
    options.AddPolicy("PublicCors", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });

    options.AddPolicy("PartnerCors", policy =>
    {
        policy
            .WithOrigins(
                "http://dev.freemold.net",
                "https://www.freemold.net"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


// ========================================================
// Database
// ========================================================

// MSSQL - 직접 Connection 사용
builder.Services.AddScoped<DbConn>(_ =>
{
    return new DbConn(connectionString);
});


// MSSQL - EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});


// PostgreSQL
builder.Services.AddScoped<PgDbConn>(_ =>
{
    return new PgDbConn(pgConnStr);
});


// ========================================================
// Options
// ========================================================

builder.Services.Configure<StorageOptions>(
    builder.Configuration.GetSection("Storage")
);


// ========================================================
// Common
// ========================================================

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();


// ========================================================
// Repository
// ========================================================

builder.Services.AddScoped<CommonRepository>();
builder.Services.AddScoped<MemberRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<EmailRepository>();
builder.Services.AddScoped<BannerRepository>();


// ========================================================
// Service
// ========================================================

builder.Services.AddScoped<ISendgridService, SendgridService>();

// BannerRepository / AppDbContext를 사용하므로 Scoped 권장
builder.Services.AddScoped<IBannerService, BannerService>();

builder.Services.AddScoped<IEmailService>(provider =>
{
    var env = provider.GetRequiredService<IWebHostEnvironment>();

    return new EmailService(env.ContentRootPath);
});

builder.Services.AddScoped<IFreemoldService, FreemoldService>();
builder.Services.AddScoped<IFileService, FileService>();


// ========================================================
// Build
// ========================================================

var app = builder.Build();


// ========================================================
// Development
// ========================================================

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}


// ========================================================
// Middleware
// ========================================================

app.UseRouting();


// PublicCors를 기본으로 사용할 경우
app.UseCors("PublicCors");


app.UseAuthorization();


// ========================================================
// Controller Mapping
// ReflectionTypeLoadException 진단 포함
// ========================================================

try
{
    app.MapControllers();
}
catch (ReflectionTypeLoadException ex)
{
    var sb = new StringBuilder();

    sb.AppendLine("======================================");
    sb.AppendLine("ReflectionTypeLoadException");
    sb.AppendLine("======================================");
    sb.AppendLine();

    sb.AppendLine("기본 오류:");
    sb.AppendLine(ex.Message);
    sb.AppendLine();

    sb.AppendLine("LoaderExceptions:");
    sb.AppendLine();

    for (int i = 0; i < ex.LoaderExceptions.Length; i++)
    {
        var loaderEx = ex.LoaderExceptions[i];

        if (loaderEx == null)
            continue;

        sb.AppendLine($"---------- [{i}] ----------");
        sb.AppendLine($"Type : {loaderEx.GetType().FullName}");
        sb.AppendLine($"Message : {loaderEx.Message}");
        sb.AppendLine();
        sb.AppendLine(loaderEx.ToString());
        sb.AppendLine();
    }

    var errorMessage = sb.ToString();

    // Visual Studio 출력창 / Console
    Console.WriteLine(errorMessage);

    // 실행 폴더에 파일 생성
    var errorFile = Path.Combine(
        AppContext.BaseDirectory,
        "ReflectionTypeLoadError.txt"
    );

    File.WriteAllText(
        errorFile,
        errorMessage,
        Encoding.UTF8
    );

    throw;
}


// ========================================================
// Run
// ========================================================

app.Run();