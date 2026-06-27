using AutoMapper;
using BeautyBooking.Domain.Contracts;
using BeautyBooking.Domain.Models;
using BeautyBooking.SharedKernel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautyBooking.Domain.Exceptions;

namespace BeautyBooking.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IBeautyBookingUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IBeautyBookingUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _unitOfWork.Employees.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);

            if (employee == null)
                return null;

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<int> CreateAsync(CreateEmployeeDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);

            await _unitOfWork.Employees.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();

            return employee.Id;
        }

        public async Task UpdateAsync(int id, UpdateEmployeeDto dto)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);

            if (employee == null)
                throw new NotFoundException("Nie znaleziono pracownika.");

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Email = dto.Email;
            employee.Position = dto.Position;

            _unitOfWork.Employees.Update(employee);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);

            if (employee == null)
                throw new NotFoundException("Nie znaleziono pracownika.");

            _unitOfWork.Employees.Delete(employee);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
