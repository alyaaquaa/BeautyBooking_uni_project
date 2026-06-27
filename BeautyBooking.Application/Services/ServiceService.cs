using BeautyBooking.Domain.Contracts;
using BeautyBooking.Domain.Models;
using BeautyBooking.SharedKernel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BeautyBooking.Domain.Exceptions;
using BeautyBooking.SharedKernel.Parameters;

namespace BeautyBooking.Application.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IBeautyBookingUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceService(IBeautyBookingUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ServiceDto>> GetAllAsync()
        {
            var services = await _unitOfWork.Services.GetAllAsync();
            return _mapper.Map<IEnumerable<ServiceDto>>(services);
        }

        public async Task<ServiceDto?> GetByIdAsync(int id)
        {
            var service = await _unitOfWork.Services.GetByIdAsync(id);

            if (service == null)
            {
                return null;
            }

            return _mapper.Map<ServiceDto>(service);
        }

        public async Task<int> CreateAsync(CreateServiceDto dto)
        {
            var service = _mapper.Map<Service>(dto);

            await _unitOfWork.Services.AddAsync(service);
            await _unitOfWork.SaveChangesAsync();

            return service.Id;
        }

        public async Task UpdateAsync(int id, UpdateServiceDto dto)
        {
            var service = await _unitOfWork.Services.GetByIdAsync(id);

            if (service == null)
            {
                throw new NotFoundException("Nie znaleziono usługi.");
            }

            service.Name = dto.Name;
            service.Description = dto.Description;
            service.Price = dto.Price;
            service.DurationMinutes = dto.DurationMinutes;

            _unitOfWork.Services.Update(service);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var service = await _unitOfWork.Services.GetByIdAsync(id);

            if (service == null)
            {
                throw new NotFoundException("Nie znaleziono usługi.");
            }

            _unitOfWork.Services.Delete(service);
            await _unitOfWork.SaveChangesAsync();
        }
        public IEnumerable<ServiceDto> GetServices(ServiceParameters parameters)
        {
            var services =
                _unitOfWork.Services.GetServices(parameters);

            return _mapper.Map<IEnumerable<ServiceDto>>(services);
        }
    }
}
