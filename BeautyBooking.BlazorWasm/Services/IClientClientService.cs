using BeautyBooking.SharedKernel.Dto;

namespace BeautyBooking.BlazorWasm.Services;

public interface IClientClientService
{
    Task<IEnumerable<ClientDto>> GetAllAsync();
    Task<ClientDto?> GetByIdAsync(int id);
    Task CreateAsync(CreateClientDto dto);
    Task UpdateAsync(int id, UpdateClientDto dto);
    Task DeleteAsync(int id);
}