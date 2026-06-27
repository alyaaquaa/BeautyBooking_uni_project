using BeautyBooking.SharedKernel.Dto;

namespace BeautyBooking.BlazorWasm.Services;

public interface IAuthClientService
{
    LoggedUserDto? CurrentUser { get; }

    event Action? OnChange;

    Task InitializeAsync();

    Task<LoggedUserDto?> LoginAsync(LoginDto dto);

    Task<LoggedUserDto?> RegisterAsync(RegisterDto dto);

    Task Logout();
}