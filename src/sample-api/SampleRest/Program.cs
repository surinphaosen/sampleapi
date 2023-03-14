using Microsoft.EntityFrameworkCore;
using SampleRest.Models;
using SampleRest.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Npgsql");
builder.Services.AddDbContext<SampleApiContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(p => p.AddPolicy("corsapp", options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseAuthorization();

app.MapControllers();

app.Run();