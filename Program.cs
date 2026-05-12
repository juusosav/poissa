using PoissaHR.Components;
using PoissaHR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using PoissaHR.Infrastructure.Data.Seeds;
using PoissaHR.Application.Services.EmployeeService;
using PoissaHR.Application.Services.DepartmentService;
using PoissaHR.Application.Services.AbsenceService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var projectRoot = builder.Environment.ContentRootPath;
var dbPath = Path.Combine(projectRoot, "poissahr.db");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

builder.Services.AddMudServices();

// Domain services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAbsenceService, AbsenceService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await DbSeeder.SeedAsync(dbContext);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
