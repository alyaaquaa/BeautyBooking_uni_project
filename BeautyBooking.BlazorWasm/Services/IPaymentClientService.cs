using BeautyBooking.SharedKernel.Dto;

namespace BeautyBooking.BlazorWasm.Services;

public interface IPaymentClientService
{
    Task<IEnumerable<PaymentDto>> GetAllAsync();
    Task<PaymentDto?> GetByIdAsync(int id);
    Task CreateAsync(CreatePaymentDto dto);
    Task UpdateAsync(int id, UpdatePaymentDto dto);
    Task DeleteAsync(int id);
}