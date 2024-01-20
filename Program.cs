using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Hypta_Projekt.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Hypta_ProjektContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Hypta_ProjektContext") ?? throw new InvalidOperationException("Connection string 'Hypta_ProjektContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
