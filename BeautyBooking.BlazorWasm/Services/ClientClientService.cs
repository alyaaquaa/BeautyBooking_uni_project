using BeautyBooking.SharedKernel.Dto;
using System.Net.Http.Json;

namespace BeautyBooking.BlazorWasm.Services;

public class ClientClientService : IClientClientService
{
    private readonly HttpClient _httpClient;

    public ClientClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ClientDto>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ClientDto>>("api/Client")
               ?? new List<ClientDto>();
    }

    public async Task<ClientDto?> GetByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<ClientDto>($"api/Client/{id}");
    }

    public async Task CreateAsync(CreateClientDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Client", dto);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Błąd dodawania klienta: {response.StatusCode} {error}");
        }
    }

    public async Task UpdateAsync(int id, UpdateClientDto dto)
    {
        await _httpClient.PutAsJsonAsync($"api/Client/{id}", dto);
    }

    public async Task DeleteAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/Client/{id}");
    }
}