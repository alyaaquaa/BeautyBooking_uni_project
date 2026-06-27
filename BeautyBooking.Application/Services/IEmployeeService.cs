using BeautyBooking.SharedKernel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautyBooking.Domain.Exceptions;

namespace BeautyBooking.Application.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();

        Task<EmployeeDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(CreateEmployeeDto dto);

        Task UpdateAsync(int id, UpdateEmployeeDto dto);

        Task DeleteAsync(int id);
    }
}
