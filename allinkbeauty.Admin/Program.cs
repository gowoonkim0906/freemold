using Freemold.Modules.Common;
using Freemold.Modules.Repositories;
using Freemold.Modules.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

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
    options.Cookie.IsEssential = true; // 동의 없이도 필수 쿠키로 사용
});

var app = builder.Build();

// Configure the HTTP request pipeline.
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

    //Repository 등록
    builder.Services.AddScoped<MemberRepository>();
    builder.Services.AddScoped<StatisticsRepository>();
    builder.Services.AddScoped<CommunityRepository>();
    builder.Services.AddScoped<ProductRepository>();
    builder.Services.AddScoped<CodeRepository>();

}
