using PetAdoption;
using Microsoft.EntityFrameworkCore;
using PetAdoption.Controllers;
using PetAdoption.Interfaces;
using PetAdoption.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Associate service interfaces with their implementations
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();

var connectionString = builder.Configuration.GetConnectionString("MyAppCs");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for Petion scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
