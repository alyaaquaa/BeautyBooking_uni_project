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
    public class ClientService : IClientService
    {
        private readonly IBeautyBookingUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientService(IBeautyBookingUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientDto>> GetAllAsync()
        {
            var clients = await _unitOfWork.Clients.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientDto>>(clients);
        }

        public async Task<ClientDto?> GetByIdAsync(int id)
        {
            var client = await _unitOfWork.Clients.GetByIdAsync(id);

            if (client == null)
            {
                return null;
            }

            return _mapper.Map<ClientDto>(client);
        }

        public async Task<int> CreateAsync(CreateClientDto dto)
        {
            var client = _mapper.Map<Client>(dto);

            await _unitOfWork.Clients.AddAsync(client);
            await _unitOfWork.SaveChangesAsync();

            return client.Id;
        }

        public async Task UpdateAsync(int id, UpdateClientDto dto)
        {
            var client = await _unitOfWork.Clients.GetByIdAsync(id);

            if (client == null)
            {
                throw new NotFoundException("Nie znaleziono klienta.");
            }

            client.FirstName = dto.FirstName;
            client.LastName = dto.LastName;
            client.Email = dto.Email;
            client.PhoneNumber = dto.PhoneNumber;

            _unitOfWork.Clients.Update(client);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var client = await _unitOfWork.Clients.GetByIdAsync(id);

            if (client == null)
            {
                throw new NotFoundException("Nie znaleziono klienta.");
            }

            _unitOfWork.Clients.Delete(client);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
