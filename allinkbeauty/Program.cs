using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Freemold.Modules.Repositories;
using Freemold.Modules.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;



var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<DbConn>(provider =>
{
    return new DbConn(connectionString);

});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContextFactory<AppDbContext>(
    options => options.UseSqlServer(connectionString),
    ServiceLifetime.Scoped
);

ConfigureServices(builder);

// Add services to the container.
builder.Services.AddControllersWithViews()
.AddRazorRuntimeCompilation();



builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.Name = ".MySessionStartDemo.Session";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; // ���� ���̵� �ʼ� ��Ű�� ���
});

builder.Services
    .AddOptions<StorageOptions>()
    .Bind(builder.Configuration.GetSection("Storage"))
    .Validate(o => !string.IsNullOrWhiteSpace(o.RootPath), "Storage:RootPath is required.")
    .ValidateOnStart();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
    // ���Ȼ� "�ŷ� ������" ���Ͻø� �ݵ�� ����
    KnownProxies = { IPAddress.Parse("127.0.0.1") } // ��: ���� ������ Nginx
    // �Ǵ� KnownNetworks.Add(...)
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession();

app.UseMiddleware<Middlewares.SessionStartMiddleware>();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();


void ConfigureServices(WebApplicationBuilder builder)
{

    builder.Services.AddHttpClient();
    builder.Services.AddScoped<IAllinkbeautyService, AllinkbeautyService>();
    builder.Services.AddScoped<ICodeService, CodeService>();
    builder.Services.AddScoped<IFileService, FileService>();

    //Repository ���
    builder.Services.AddScoped<MemberRepository>();
    builder.Services.AddScoped<StatisticsRepository>();
    builder.Services.AddScoped<CommunityRepository>();
    builder.Services.AddScoped<ProductRepository>();
    builder.Services.AddScoped<CodeRepository>();

}
