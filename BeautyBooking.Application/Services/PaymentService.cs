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
    public class PaymentService : IPaymentService
    {
        private readonly IBeautyBookingUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentService(IBeautyBookingUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentDto>> GetAllAsync()
        {
            var payments = await _unitOfWork.Payments.GetAllAsync();
            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public async Task<PaymentDto?> GetByIdAsync(int id)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);

            if (payment == null)
                return null;

            return _mapper.Map<PaymentDto>(payment);
        }

        public async Task<int> CreateAsync(CreatePaymentDto dto)
        {
            var payment = _mapper.Map<Payment>(dto);

            await _unitOfWork.Payments.AddAsync(payment);
            await _unitOfWork.SaveChangesAsync();

            return payment.Id;
        }

        public async Task UpdateAsync(int id, UpdatePaymentDto dto)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);

            if (payment == null)
                throw new NotFoundException("Nie znaleziono płatności.");

            payment.ReservationId = dto.ReservationId;
            payment.Amount = dto.Amount;
            payment.PaymentDate = dto.PaymentDate;
            payment.PaymentMethod = dto.PaymentMethod;
            payment.IsPaid = dto.IsPaid;

            _unitOfWork.Payments.Update(payment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);

            if (payment == null)
                throw new NotFoundException("Nie znaleziono płatności.");

            _unitOfWork.Payments.Delete(payment);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
