using AutoMapper;
using BeautyBooking.Domain.Models;
using BeautyBooking.SharedKernel.Dto;

namespace BeautyBooking.Application.Mappings
{
    public class BeautyBookingMappingProfile : Profile
    {
        public BeautyBookingMappingProfile()
        {
            // SERVICE
            CreateMap<Service, ServiceDto>();
            CreateMap<CreateServiceDto, Service>();
            CreateMap<UpdateServiceDto, Service>();

            // CLIENT
            CreateMap<Client, ClientDto>();
            CreateMap<CreateClientDto, Client>();
            CreateMap<UpdateClientDto, Client>();

            // EMPLOYEE
            CreateMap<Employee, EmployeeDto>();
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();

            // RESERVATION
            CreateMap<Reservation, ReservationDto>();
            CreateMap<CreateReservationDto, Reservation>();
            CreateMap<UpdateReservationDto, Reservation>();

            // PAYMENT
            CreateMap<Payment, PaymentDto>();
            CreateMap<CreatePaymentDto, Payment>();
            CreateMap<UpdatePaymentDto, Payment>();
        }
    }
}