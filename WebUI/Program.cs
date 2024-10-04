using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ders 46
builder.Services.AddSession();

// ders 45
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddMvc();

builder.Services.AddScoped<EfBlogRepository>();
builder.Services.AddScoped<EfCommentRepository>();
builder.Services.AddScoped<EfContactRepository>();
builder.Services.AddScoped<EfCategoryReposiyory>();
builder.Services.AddScoped<EfAboutRepository>();
builder.Services.AddScoped<EfMessageRepository>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    x => x.LoginPath = "/Login/Index"
);

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.SlidingExpiration = true;
    options.AccessDeniedPath = new PathString("/Login/AccessDenied");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
    options.LoginPath = "/Login/Index";
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<BlogContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("local")));

builder.Services.AddScoped<BlogContext>();

builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
    x.Password.RequireUppercase = false;
    x.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<BlogContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<BlogContext>();
    await Seeder.SeedAsync(context, services.GetRequiredService<UserManager<AppUser>>());
}
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");

app.UseAuthentication();

// ders 46
app.UseSession();
// app.UseEndpoints(endpoints =>
// {
//     _ = endpoints.MapControllerRoute(
//       name: "areas",
//       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//     );
// });
app.Run();
