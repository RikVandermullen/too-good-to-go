using HotChocolate.AspNetCore.Playground;
using HotChocolate.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TGTG_EF;
using TGTG_GraphQL.GraphQL;

var builder = WebApplication.CreateBuilder(args);

var ConnectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddScoped<TGTGDbContext>().AddDbContext<TGTGDbContext>(options => options.UseSqlServer(ConnectionString));

builder.Services.AddScoped<IStudentRepository, StudentEFRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeEFRepository>();
builder.Services.AddScoped<IProductRepository, ProductEFRepository>();
builder.Services.AddScoped<IPacketRepository, PacketEFRepository>();
builder.Services.AddScoped<ICanteenRepository, CanteenEFRepository>();
builder.Services.AddScoped<StudentQuery>();
builder.Services.AddScoped<StudentMutation>();
builder.Services.AddScoped<CanteenQuery>();
builder.Services.AddScoped<CanteenMutation>();
builder.Services.AddScoped<ProductQuery>();
builder.Services.AddScoped<ProductMutation>();
builder.Services.AddScoped<EmployeeQuery>();
builder.Services.AddScoped<EmployeeMutation>();
builder.Services.AddScoped<PacketQuery>();
builder.Services.AddScoped<PacketMutation>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType(q => q.Name("Query"))
    .AddMutationType(d => d.Name("Mutation"))
    .AddType<StudentQuery>()
    .AddType<CanteenQuery>()
    .AddType<ProductQuery>()
    .AddType<EmployeeQuery>()
    .AddType<PacketQuery>()
    .AddTypeExtension<StudentMutation>()
    .AddTypeExtension<CanteenMutation>()
    .AddTypeExtension<ProductMutation>()
    .AddTypeExtension<EmployeeMutation>()
    .AddTypeExtension<PacketMutation>();
    

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UsePlayground(new PlaygroundOptions
    {
        QueryPath = "/api",
        Path = "/playground"
    });
}

app.MapGraphQL();
app.UseRouting();

app.Run();
