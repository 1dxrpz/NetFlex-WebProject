using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.Identity.Owin;
using AspNet.Security.OAuth.Vkontakte;
using NetFlex.DAL.EF;
using Microsoft.AspNetCore.Authentication.Cookies;
using NetFlex.BLL.Interfaces;
using NetFlex.BLL.Services;
using NetFlex.DAL.Interfaces;
using NetFlex.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>(options => options.UseNpgsql(
                    builder.Configuration.GetConnectionString("DatabaseContextConnection")
                )
            );

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DatabaseContext>();

builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<IVideoService, VideoService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuthentication()
.AddVkontakte(options =>
{
    options.ClientId = builder.Configuration["VKontakte:ClientId"];
    options.ClientSecret = builder.Configuration["VKontakte:ClientSecret"];
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
