using BeautyBooking.BlazorWasm;
using BeautyBooking.BlazorWasm.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BeautyBooking.BlazorWasm.Services;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://beautybooking-uni-project.onrender.com/")
});

builder.Services.AddScoped<IServiceClientService, ServiceClientService>();
builder.Services.AddScoped<IClientClientService, ClientClientService>();
builder.Services.AddScoped<IEmployeeClientService, EmployeeClientService>();
builder.Services.AddScoped<IReservationClientService, ReservationClientService>();
builder.Services.AddScoped<IPaymentClientService, PaymentClientService>();
builder.Services.AddScoped<IAuthClientService, AuthClientService>();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();