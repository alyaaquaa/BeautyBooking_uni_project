using BeautyBooking.SharedKernel.Dto;
using System.Net.Http.Json;

namespace BeautyBooking.BlazorWasm.Services;

public class EmployeeClientService : IEmployeeClientService
{
    private readonly HttpClient _httpClient;

    public EmployeeClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<EmployeeDto>>("api/Employee")
               ?? new List<EmployeeDto>();
    }

    public async Task<EmployeeDto?> GetByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<EmployeeDto>($"api/Employee/{id}");
    }

    public async Task CreateAsync(CreateEmployeeDto dto)
    {
        await _httpClient.PostAsJsonAsync("api/Employee", dto);
    }

    public async Task UpdateAsync(int id, UpdateEmployeeDto dto)
    {
        await _httpClient.PutAsJsonAsync($"api/Employee/{id}", dto);
    }

    public async Task DeleteAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/Employee/{id}");
    }
}