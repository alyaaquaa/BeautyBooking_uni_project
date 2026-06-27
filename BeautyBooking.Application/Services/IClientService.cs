using BeautyBooking.SharedKernel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautyBooking.Domain.Exceptions;

namespace BeautyBooking.Application.Services
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllAsync();

        Task<ClientDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(CreateClientDto dto);

        Task UpdateAsync(int id, UpdateClientDto dto);

        Task DeleteAsync(int id);
    }
}
