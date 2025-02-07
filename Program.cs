using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KhumalocraftEmporium_ST10069127_CLDV6211POE.Data;
using Microsoft.AspNetCore.SignalR;
using KhumalocraftEmporium_ST10069127_CLDV6211POE.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add database context (SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add controllers with views
builder.Services.AddControllersWithViews();

// Add SignalR Service
builder.Services.AddSignalR();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Map SignalR Hub
app.MapHub<OrderHub>("/orderHub");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MyWork}/{action=Index}/{id?}");

app.Run();
