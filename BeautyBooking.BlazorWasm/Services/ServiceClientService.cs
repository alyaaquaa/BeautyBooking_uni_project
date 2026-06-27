using BeautyBooking.SharedKernel.Dto;
using System.Net.Http.Json;

namespace BeautyBooking.BlazorWasm.Services;

public class ServiceClientService : IServiceClientService
{
    private readonly HttpClient _httpClient;

    public ServiceClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ServiceDto>> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<IEnumerable<ServiceDto>>("api/Service");

        return result ?? new List<ServiceDto>();
    }

    public async Task<ServiceDto?> GetByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<ServiceDto>($"api/Service/{id}");
    }
    public async Task CreateAsync(CreateServiceDto dto)
    {
        await _httpClient.PostAsJsonAsync("api/Service", dto);
    }
    public async Task UpdateAsync(int id, UpdateServiceDto dto)
    {
        await _httpClient.PutAsJsonAsync($"api/Service/{id}", dto);
    }
    public async Task DeleteAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/Service/{id}");
    }
}