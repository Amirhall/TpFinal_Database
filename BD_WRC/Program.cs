using BD_WRC.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add DbContext
builder.Services.AddDbContext<BD_WRCContext>(
    options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("BD_WRC"));
        options.UseLazyLoadingProxies();
    });

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Utilisateurs/Connexion";
    options.LogoutPath = "/Utilisateurs/Deconnexion";
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Classements}/{action=RechercheCourse}"
);

app.MapRazorPages();

app.Run();
