using BeautyBooking.SharedKernel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautyBooking.Domain.Exceptions;

namespace BeautyBooking.Application.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationDto>> GetAllAsync();

        Task<ReservationDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(CreateReservationDto dto);

        Task UpdateAsync(int id, UpdateReservationDto dto);

        Task DeleteAsync(int id);
    }
}
