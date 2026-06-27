using BeautyBooking.SharedKernel.Dto;

namespace BeautyBooking.BlazorWasm.Services;

public interface IReservationClientService
{
    Task<IEnumerable<ReservationDto>> GetAllAsync();
    Task<ReservationDto?> GetByIdAsync(int id);
    Task CreateAsync(CreateReservationDto dto);
    Task UpdateAsync(int id, UpdateReservationDto dto);
    Task DeleteAsync(int id);
}