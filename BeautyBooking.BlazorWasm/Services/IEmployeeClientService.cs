using BeautyBooking.SharedKernel.Dto;

namespace BeautyBooking.BlazorWasm.Services;

public interface IEmployeeClientService
{
    Task<IEnumerable<EmployeeDto>> GetAllAsync();
    Task<EmployeeDto?> GetByIdAsync(int id);
    Task CreateAsync(CreateEmployeeDto dto);
    Task UpdateAsync(int id, UpdateEmployeeDto dto);
    Task DeleteAsync(int id);
}