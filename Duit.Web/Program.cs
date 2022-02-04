using Duit.DAL;
using System.Configuration;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DuitContext>(options =>
    options.UseInMemoryDatabase("DuitData")); //UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(
        CertificateAuthenticationDefaults.AuthenticationScheme)
    .AddCertificate();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
