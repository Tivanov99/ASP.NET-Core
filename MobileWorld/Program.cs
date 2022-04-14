using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MobileWorld.Core.Contracts;
using MobileWorld.Core.Services;
using MobileWorld.Infrastructure.Data;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.Identity;
using MobileWorld.ModelBinders;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>
    (options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    })
    .AddMvcOptions(options =>
 {
     options.ModelBinderProviders.Insert(1, new DateTimeModelBinderProvider());
 });

builder.Services
    .AddScoped<IUserService, UserService>()
.AddScoped<ICarService, CarService>()
.AddScoped<IAdminService, AdminService>()
.AddScoped<IAdminRepository, AdminRepository>()
.AddScoped<IUnitOfWork, UnitOfWork>()
.AddScoped<IAdRepository, AdRepository>()
.AddScoped<ICarRepository, CarRepository>()
.AddScoped<IAdService, AdService>()
.AddScoped<ITownRepository, TownRepository>()
.AddScoped<IUserRepository, UserRepository>()
.AddScoped<DbContext, ApplicationDbContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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



