using BeautyBooking.SharedKernel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautyBooking.Domain.Exceptions;
using BeautyBooking.SharedKernel.Parameters;

namespace BeautyBooking.Application.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceDto>> GetAllAsync();

        Task<ServiceDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(CreateServiceDto dto);

        Task UpdateAsync(int id, UpdateServiceDto dto);

        Task DeleteAsync(int id);
        IEnumerable<ServiceDto> GetServices(ServiceParameters parameters);
    }
}
