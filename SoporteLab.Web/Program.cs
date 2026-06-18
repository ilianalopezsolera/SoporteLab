using SoporteLab.Web.Components;
using SoporteLab.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Registrar HttpClient apuntando a la API
builder.Services.AddHttpClient<TicketApiService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5039/");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();