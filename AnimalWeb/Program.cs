using Microsoft.EntityFrameworkCore;
using AnimalWeb.Data;
using AnimalWeb.Repositories;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddTransient<IRepository, MyRepository>();
builder.Services.AddTransient<IUserRepository, MyUserRepository>();
builder.Services.AddDbContext<Context>(options => options.UseSqlite(connectionString));
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication()
   .AddGoogle(options =>
    {
        IConfigurationSection googleAuthNSection =
        config.GetSection("Authentication:Google");
        options.ClientId = googleAuthNSection["123506300981-6d75gsged3d7unp6dq13nf1rp665kh3s.apps.googleusercontent.com"];
        options.ClientSecret = googleAuthNSection["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"];
    })
    .AddFacebook(options =>
    {
        IConfigurationSection FBAuthNSection =
        config.GetSection("Authentication:FB");
        options.ClientId = FBAuthNSection["775363860471658"];
        options.ClientSecret = FBAuthNSection["9f81d207f7220a6d9973e5f41677b2db"];
    });
//.AddMicrosoftAccount(microsoftOptions =>
//{
//    microsoftOptions.ClientId = config["Authentication:Microsoft:ClientId"];
//    microsoftOptions.ClientSecret = config["Authentication:Microsoft:ClientSecret"];
//})
//.AddTwitter(twitterOptions =>
//{
//    twitterOptions.ConsumerKey = config["Authentication:Twitter:ConsumerAPIKey"];
//    twitterOptions.ConsumerSecret = config["Authentication:Twitter:ConsumerSecret"];
//    twitterOptions.RetrieveUserDetails = true;
//});

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
