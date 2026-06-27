using BeautyBooking.SharedKernel.Dto;
using System.Net.Http.Json;

namespace BeautyBooking.BlazorWasm.Services;

public class PaymentClientService : IPaymentClientService
{
    private readonly HttpClient _httpClient;

    public PaymentClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<PaymentDto>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<PaymentDto>>("api/Payment")
               ?? new List<PaymentDto>();
    }

    public async Task<PaymentDto?> GetByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<PaymentDto>($"api/Payment/{id}");
    }

    public async Task CreateAsync(CreatePaymentDto dto)
    {
        await _httpClient.PostAsJsonAsync("api/Payment", dto);
    }

    public async Task UpdateAsync(int id, UpdatePaymentDto dto)
    {
        await _httpClient.PutAsJsonAsync($"api/Payment/{id}", dto);
    }

    public async Task DeleteAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/Payment/{id}");
    }
}