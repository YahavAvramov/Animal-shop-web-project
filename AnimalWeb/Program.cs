using Microsoft.EntityFrameworkCore;
using AnimalWeb.Data;
using AnimalWeb.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IRepository, MyRepository>();
builder.Services.AddTransient<IUserRepository, MyUserRepository>();
builder.Services.AddDbContext<Context>(options => options.UseSqlite("Data Source=c:\\temp\\example4.db"));
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<Context>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
