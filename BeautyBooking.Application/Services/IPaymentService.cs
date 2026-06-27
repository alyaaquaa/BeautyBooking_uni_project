using BeautyBooking.SharedKernel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautyBooking.Domain.Exceptions;

namespace BeautyBooking.Application.Services
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetAllAsync();

        Task<PaymentDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(CreatePaymentDto dto);

        Task UpdateAsync(int id, UpdatePaymentDto dto);

        Task DeleteAsync(int id);
    }
}
