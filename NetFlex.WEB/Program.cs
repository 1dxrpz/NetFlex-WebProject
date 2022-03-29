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
using NetFlex.DAL.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>(options => options.UseNpgsql(
                    builder.Configuration.GetConnectionString("DatabaseContextConnection")
                )
            );

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(opts => {
    opts.User.RequireUniqueEmail = true;    // уникальный email
    opts.User.AllowedUserNameCharacters = ".@abcdefghijklmnopqrstuvwxyz"; // допустимые символы
})
    .AddEntityFrameworkStores<DatabaseContext>();

builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IVideoService, VideoService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IRatingService, RatingService>();


builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizePage("/Contact");
    options.Conventions.AuthorizeFolder("/Private");
    options.Conventions.AllowAnonymousToPage("/Private/PublicPage");
    options.Conventions.AllowAnonymousToFolder("/Private/PublicPages");
});

builder.Services.AddAuthentication()
.AddVkontakte(options =>
{
    options.ClientId = builder.Configuration["VKontakte:ClientId"];
    options.ClientSecret = builder.Configuration["VKontakte:ClientSecret"];
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Constants.Policies.RequireAdmin, policy => policy.RequireRole(Constants.Roles.Administrator));
    options.AddPolicy(Constants.Policies.RequireManager, policy => policy.RequireRole(Constants.Roles.Manager));
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
    pattern: "{controller=Main}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

