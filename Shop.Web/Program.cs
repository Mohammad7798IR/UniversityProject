using Shop.Data.Context;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Identity;
using Shop.IoC;
using Microsoft.AspNetCore.Authentication.Cookies;
using GoogleReCaptcha.V3.Interface;
using GoogleReCaptcha.V3;
using MyChat;
using MarketPlace.DataLayer.Repository;

var builder = WebApplication.CreateBuilder(args);
IConfiguration _configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSignalR();

builder.Services.AddHttpClient<ICaptchaValidator, GoogleReCaptchaValidator>();





builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<MollaShopDBContext>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<MollaShopDBContext>(oprions =>
{
    oprions.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

}).AddCookie(options =>
{
    options.Cookie.Name = "MollaCookie";
    options.LoginPath = "/SignIn";
    options.LogoutPath = "/SignIn";
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
});

RegisterServices(builder.Services);




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();



app.UseRouting();

app.UseStatusCodePagesWithReExecute("/ErrorHandler/Index", "?statusCode={0}");

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
         name: "User",
         pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
         name: "SupportAgent",
         pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
         name: "Admin",
         pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
         name: "Seller",
         pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    //endpoints.MapHub<ChatHub>("/ChatHub");
    //endpoints.MapHub<AgentHub>("/agentHub");
});

//app.UseCors(builder=>builder.WithOrigins());

app.Run();



void RegisterServices(IServiceCollection services)
{
    DependencyContainer.ReisterService(services);
}