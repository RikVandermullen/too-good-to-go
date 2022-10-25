using DomainServices;
using Microsoft.EntityFrameworkCore;
using TGTG_EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddScoped<TGTGDbContext>().AddDbContext<TGTGDbContext>(options => options.UseSqlServer(ConnectionString).EnableSensitiveDataLogging());

builder.Services.AddScoped<IStudentRepository, StudentEFRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeEFRepository>();
builder.Services.AddScoped<ICanteenRepository, CanteenEFRepository>();
builder.Services.AddScoped<IProductRepository, ProductEFRepository>();
builder.Services.AddScoped<IPacketRepository, PacketEFRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
