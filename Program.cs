using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PROIECT_SESIUNE_VINURI.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PROIECT_SESIUNE_VINURIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PROIECT_SESIUNE_VINURIContext") ?? throw new InvalidOperationException("Connection string 'PROIECT_SESIUNE_VINURIContext' not found.")));

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
