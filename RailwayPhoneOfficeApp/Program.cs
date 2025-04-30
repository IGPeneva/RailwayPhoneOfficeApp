using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RailwayPhoneOfficeApp.Data;
using RailwayPhoneOfficeApp.Data.Models;
using RailwayPhoneOfficeApp.Data.Utilities;
using RailwayPhoneOfficeApp.Data.Utilities.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("RailwayPhoneOfficeAppDbConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<RailwayPhoneOfficeDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IValidator, EntityValidator>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddIdentity<ApplicationUser,IdentityRole<Guid>>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<RailwayPhoneOfficeDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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

using (var scope = app.Services.CreateScope())
{
    IServiceProvider services = scope.ServiceProvider;
    RailwayPhoneOfficeDbContext dbContext = services.GetRequiredService<RailwayPhoneOfficeDbContext>();
    IValidator entityValidator = services.GetRequiredService<IValidator>();
    ILogger<DataProcessor> logger = services.GetRequiredService<ILogger<DataProcessor>>();

    DataProcessor dataProcessor = new DataProcessor(entityValidator, logger);

    //await DataProcessor.ImportTelephoneExchangesFromJson(dbContext);
}

app.Run();
