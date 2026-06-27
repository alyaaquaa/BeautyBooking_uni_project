using BeautyBooking.Application.Mappings;
using BeautyBooking.Application.Services;
using BeautyBooking.Domain.Contracts;
using BeautyBooking.Infrastructure;
using Microsoft.EntityFrameworkCore;
using BeautyBooking.WebAPI.Middleware;
using BeautyBooking.Application.Validators;
using BeautyBooking.SharedKernel.Dto;
using FluentValidation;
using FluentValidation.AspNetCore;
using NLog.Web;




var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseNLog();


// KONTROLERY WEB API
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();


// BAZA DANYCH SQLITE
builder.Services.AddDbContext<BeautyBookingDbContext>(options =>
    options.UseSqlite(
        "Data Source=C:/Users/alyaa/Downloads/IiE/II SEMESTR/C/projekt/beautybooking.db"));


// DEPENDENCY INJECTION
// Rejestracja serwisów
builder.Services.AddScoped<IBeautyBookingUnitOfWork, BeautyBookingUnitOfWork>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<DataSeeder>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<ExceptionMiddleware>();
builder.Services.AddScoped<IValidator<CreateServiceDto>, CreateServiceDtoValidator>();
builder.Services.AddScoped<IValidator<CreateClientDto>, CreateClientDtoValidator>();
builder.Services.AddScoped<IValidator<CreateEmployeeDto>, CreateEmployeeDtoValidator>();
builder.Services.AddScoped<IValidator<CreateReservationDto>, CreateReservationDtoValidator>();
builder.Services.AddScoped<IValidator<CreatePaymentDto>, CreatePaymentDtoValidator>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IValidator<UpdateServiceDto>, UpdateServiceDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateClientDto>, UpdateClientDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateEmployeeDto>, UpdateEmployeeDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateReservationDto>, UpdateReservationDtoValidator>();
builder.Services.AddScoped<IValidator<UpdatePaymentDto>, UpdatePaymentDtoValidator>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthService, AuthService>();



// AUTOMAPPER
// Mapowanie DTO <-> Encje
builder.Services.AddAutoMapper(typeof(BeautyBookingMappingProfile));


// SWAGGER / OPENAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("BeautyBookingCors", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();


// WYPE£NIENIE BAZY
// DANYMI POCZ¥TKOWYMI
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BeautyBookingDbContext>();

    // Utworzenie bazy i tabel jeœli nie istniej¹
    dbContext.Database.EnsureCreated();

    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();

    // Dodanie danych pocz¹tkowych
    await seeder.SeedAsync();
}


// SWAGGER
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseCors("BeautyBookingCors");

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();