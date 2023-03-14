using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using SampleOData.Models;
using SampleOData.Repo;

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<Customer>("Customers");
    return builder.GetEdmModel();
}

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
    .AddOData(options => options
        .AddRouteComponents("odata", GetEdmModel())
        .Select()
        .Filter()
        .OrderBy()
        //.SetMaxTop(20)
        .Count()
        .Expand()
    );

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Npgsql");
builder.Services.AddDbContext<SampleApiContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();

//builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseAuthorization();

app.MapControllers();

app.Run();