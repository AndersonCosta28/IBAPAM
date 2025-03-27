using IBAPAM.ApiService.Data;
using IBAPAM.ApiService.Interfaces;
using IBAPAM.ApiService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.AddNpgsqlDbContext<ApplicationDbContext>("ibapamdb");
builder.Services.AddControllers();

builder.Services.AddScoped<IPublicacaoService, PublicacaoService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();
app.MapDefaultEndpoints();

app.Run();
