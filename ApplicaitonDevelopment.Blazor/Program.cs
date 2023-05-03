//using ApplicationDevelopment.Blazor.Data;
//using ApplicationDevelopment.Blazor.Data.Services;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Web;

using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ApplicationDevelopment.Blazor.Data;
using ApplicationDevelopment.Blazor.Data.DTO;
using ApplicationDevelopment.Blazor.Data.Helper;
using ApplicationDevelopment.Blazor.Data.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<CarService>();
builder.Services.AddSingleton<OfferService>();


builder.Services.AddHttpClient(Options.DefaultName, client =>
{
    // setup client
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
