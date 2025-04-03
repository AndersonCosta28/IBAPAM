using IBAPAM.ServiceDefaults;
using IBAPAM.Web.Client.Interfaces;
using IBAPAM.Web.Components;
using IBAPAM.Web.Services;
using Radzen;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddRadzenComponents();

builder.Services.AddScoped<IPublicacaoService, PublicacaoService>();
builder.Services.AddHttpClient<IPublicacaoService, PublicacaoService>(
    client => client.BaseAddress = new Uri("https+http://apiservice")
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(IBAPAM.Web.Client._Imports).Assembly);

app.Run();
