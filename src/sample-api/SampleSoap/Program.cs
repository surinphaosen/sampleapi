using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SampleSoap.Models;
using SampleSoap;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Npgsql");
builder.Services.AddDbContext<SampleApiContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<ISampleService, SampleService>();

builder.Services.AddSoapCore();
builder.Services.TryAddSingleton<ISampleService, SampleService>();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<ISampleService>("/Service.svc", new SoapEncoderOptions(), SoapSerializer.DataContractSerializer, true);
    endpoints.UseSoapEndpoint<ISampleService>("/Service.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer, true);
});

app.Run();