using BeautyBooking.SharedKernel.Dto;

namespace BeautyBooking.BlazorWasm.Services;

public interface IServiceClientService
{
    Task<IEnumerable<ServiceDto>> GetAllAsync();

    Task<ServiceDto?> GetByIdAsync(int id);
    Task CreateAsync(CreateServiceDto dto);
    Task UpdateAsync(int id, UpdateServiceDto dto);
    Task DeleteAsync(int id);
}