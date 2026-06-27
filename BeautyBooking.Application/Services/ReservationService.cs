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
    public class ReservationService : IReservationService
    {
        private readonly IBeautyBookingUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReservationService(IBeautyBookingUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReservationDto>> GetAllAsync()
        {
            var reservations = await _unitOfWork.Reservations.GetAllAsync();
            return _mapper.Map<IEnumerable<ReservationDto>>(reservations);
        }

        public async Task<ReservationDto?> GetByIdAsync(int id)
        {
            var reservation = await _unitOfWork.Reservations.GetByIdAsync(id);

            if (reservation == null)
                return null;

            return _mapper.Map<ReservationDto>(reservation);
        }

        public async Task<int> CreateAsync(CreateReservationDto dto)
        {
            var reservation = _mapper.Map<Reservation>(dto);

            reservation.ReservationItems = dto.ServiceIds
                .Select(serviceId => new ReservationItem
                {
                    ServiceId = serviceId
                })
                .ToList();

            await _unitOfWork.Reservations.AddAsync(reservation);
            await _unitOfWork.SaveChangesAsync();

            return reservation.Id;
        }

        public async Task UpdateAsync(int id, UpdateReservationDto dto)
        {
            var reservation = await _unitOfWork.Reservations.GetByIdAsync(id);

            if (reservation == null)
                throw new NotFoundException("Nie znaleziono rezerwacji.");

            reservation.ClientId = dto.ClientId;
            reservation.EmployeeId = dto.EmployeeId;
            reservation.ReservationDate = dto.ReservationDate;
            reservation.Status = dto.Status;
            reservation.Notes = dto.Notes;

            reservation.ReservationItems.Clear();

            foreach (var serviceId in dto.ServiceIds)
            {
                reservation.ReservationItems.Add(new ReservationItem
                {
                    ReservationId = reservation.Id,
                    ServiceId = serviceId
                });
            }

            _unitOfWork.Reservations.Update(reservation);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var reservation = await _unitOfWork.Reservations.GetByIdAsync(id);

            if (reservation == null)
                throw new NotFoundException("Nie znaleziono rezerwacji.");

            _unitOfWork.Reservations.Delete(reservation);
            await _unitOfWork.SaveChangesAsync();

        }


    }
}
