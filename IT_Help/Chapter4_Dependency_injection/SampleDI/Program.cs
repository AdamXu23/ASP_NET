using SampleDI.Class;
using SampleDI.Interface;
using SampleDI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IScoped, SampleClass>();
builder.Services.AddScoped<ISingleton, SampleClass>();
builder.Services.AddScoped<ITransient, SampleClass>();
builder.Services.AddScoped<SampleService, SampleService>();

