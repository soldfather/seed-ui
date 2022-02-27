using InventoryUI.Clients;
using InventoryUI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var mockDataUrl = builder.Configuration.GetValue<string>("MockDataUrl");

builder.Services.AddHttpClient<IInventoryRequestsClient, InventoryRequestsClient>(
    (client) => client.BaseAddress = new Uri(mockDataUrl)
);

builder.Services.AddTransient<IInventoryService, InventoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
