using System;
using dumplingsOrderBackend.Handlers;
using dumplingsOrderBackend.Interfaces;
using dumplingsOrderBackend.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

services.AddControllersWithViews();
services.AddSingleton<IItemRepository,ItemRepository>();
services.AddSingleton<IItemHandler,ItemHandler>();

// auto mapper
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// cors
services.AddCors(options =>
{
    options.AddPolicy(
        name: "cors",
        builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
});
                

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
app.UseCors("cors");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
