using Microsoft.EntityFrameworkCore;
using SampleGraphQL.Interfaces;
using SampleGraphQL.Models;
using SampleGraphQL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddProjections().AddFiltering().AddSorting();

var connectionString = builder.Configuration.GetConnectionString("Npgsql");
builder.Services.AddDbContext<SampleApiContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

app.MapGraphQL("/graphql");

app.Run();