using BeautyBooking.BlazorServer.Components;
using BeautyBooking.Application.Mappings;
using BeautyBooking.Application.Services;
using BeautyBooking.Domain.Contracts;
using BeautyBooking.Infrastructure;
using Microsoft.EntityFrameworkCore;
using BeautyBooking.Application.Validators;
using BeautyBooking.SharedKernel.Dto;
using FluentValidation;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// BAZA DANYCH SQLITE
builder.Services.AddDbContext<BeautyBookingDbContext>(options =>
    options.UseSqlite("Data Source=C:/Users/alyaa/Downloads/IiE/II SEMESTR/C/projekt/BeautyBooking/beautybooking.db"));

// DEPENDENCY INJECTION
builder.Services.AddScoped<IBeautyBookingUnitOfWork, BeautyBookingUnitOfWork>();
builder.Services.AddScoped<IServiceService, ServiceService>();

// AUTOMAPPER
builder.Services.AddAutoMapper(typeof(BeautyBookingMappingProfile));
builder.Services.AddScoped<DataSeeder>();
builder.Services.AddScoped<IValidator<CreateServiceDto>, CreateServiceDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateServiceDto>, UpdateServiceDtoValidator>();
builder.Services.AddRadzenComponents();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BeautyBookingDbContext>();

    dbContext.Database.EnsureCreated();

    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();

    await seeder.SeedAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
