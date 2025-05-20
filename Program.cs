var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IntegrationRickAndMortyAPI.Services.APIService>(client =>
{
    client.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
});

builder.Services.AddScoped<IntegrationRickAndMortyAPI.Services.APIService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
