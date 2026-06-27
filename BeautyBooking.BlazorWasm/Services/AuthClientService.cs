using Blazored.LocalStorage;
using BeautyBooking.SharedKernel.Dto;
using System.Net.Http.Json;

namespace BeautyBooking.BlazorWasm.Services;

public class AuthClientService : IAuthClientService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _storage;

    public LoggedUserDto? CurrentUser { get; private set; }

    public event Action? OnChange;

    public AuthClientService(HttpClient http, ILocalStorageService storage)
    {
        _http = http;
        _storage = storage;
    }

    public async Task InitializeAsync()
    {
        CurrentUser = await _storage.GetItemAsync<LoggedUserDto>("loggedUser");
        NotifyStateChanged();
    }

    public async Task<LoggedUserDto?> LoginAsync(LoginDto dto)
    {
        var response = await _http.PostAsJsonAsync("api/Auth/login", dto);

        if (!response.IsSuccessStatusCode)
            return null;

        CurrentUser = await response.Content.ReadFromJsonAsync<LoggedUserDto>();

        if (CurrentUser != null)
        {
            await _storage.SetItemAsync("loggedUser", CurrentUser);
        }

        NotifyStateChanged();

        return CurrentUser;
    }

    public async Task<LoggedUserDto?> RegisterAsync(RegisterDto dto)
    {
        var response = await _http.PostAsJsonAsync("api/Auth/register", dto);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Błąd rejestracji: {response.StatusCode} {error}");
        }

        CurrentUser = await response.Content.ReadFromJsonAsync<LoggedUserDto>();

        if (CurrentUser != null)
        {
            await _storage.SetItemAsync("loggedUser", CurrentUser);
        }

        NotifyStateChanged();

        return CurrentUser;
    }

    public async Task Logout()
    {
        CurrentUser = null;
        await _storage.RemoveItemAsync("loggedUser");

        NotifyStateChanged();
    }

    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}