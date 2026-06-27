using BeautyBooking.SharedKernel.Dto;
using System.Net.Http.Json;

namespace BeautyBooking.BlazorWasm.Services;

public class ReservationClientService : IReservationClientService
{
    private readonly HttpClient _httpClient;

    public ReservationClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ReservationDto>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ReservationDto>>("api/Reservation")
               ?? new List<ReservationDto>();
    }

    public async Task<ReservationDto?> GetByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<ReservationDto>($"api/Reservation/{id}");
    }

    public async Task CreateAsync(CreateReservationDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Reservation", dto);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Błąd zapisu rezerwacji: {response.StatusCode} {error}");
        }
    }

    public async Task UpdateAsync(int id, UpdateReservationDto dto)
    {
        await _httpClient.PutAsJsonAsync($"api/Reservation/{id}", dto);
    }

    public async Task DeleteAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/Reservation/{id}");
    }
}