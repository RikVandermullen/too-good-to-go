using TGTG_EF;
using Microsoft.EntityFrameworkCore;
using DomainServices;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var ConnectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<TGTGDbContext>(options => options.UseSqlServer(ConnectionString));

var userConnectionString = builder.Configuration.GetConnectionString("Security");
builder.Services.AddDbContext<SecurityDbContext>(options => options.UseSqlServer(userConnectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<SecurityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("OnlyPowerUsersAndUp", policy => policy
        .RequireAuthenticatedUser()
        .RequireClaim("UserType", "poweruser"));

    options.AddPolicy("OnlyRegularUsersAndUp", policy => policy
        .RequireAuthenticatedUser()
        .RequireClaim("UserType", "regularuser", "poweruser"));
});

builder.Services.AddScoped<IStudentRepository, StudentEFRepository>();
builder.Services.AddScoped<IProductRepository, ProductEFRepository>();
builder.Services.AddScoped<IPacketRepository, PacketEFRepository>();
builder.Services.AddScoped<TGTGSeedData>();
builder.Services.AddScoped<SecuritySeedData>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    await SeedDatabase();
}
else
{
    // Only in dev env seed with dummy data -->
    
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Packet}/{action=Packets}/{id?}");

app.Run();

async Task SeedDatabase()
{
    using var scope = app.Services.CreateScope();
    var dbSeeder = scope.ServiceProvider.GetRequiredService<TGTGSeedData>();
    await dbSeeder.EnsurePopulated(true);

    var dbSecuritySeeder = scope.ServiceProvider.GetRequiredService<SecuritySeedData>();
    await dbSecuritySeeder.EnsurePopulated(true);
}
