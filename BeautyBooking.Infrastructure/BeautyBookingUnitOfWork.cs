using BeautyBooking.Domain.Contracts;
using BeautyBooking.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BeautyBooking.Infrastructure
{
    public class BeautyBookingUnitOfWork : IBeautyBookingUnitOfWork
    {
        private readonly BeautyBookingDbContext _context;

        public BeautyBookingUnitOfWork(BeautyBookingDbContext context)
        {
            _context = context;

            Services = new ServiceRepository(_context);
            Clients = new ClientRepository(_context);
            Employees = new EmployeeRepository(_context);
            Reservations = new ReservationRepository(_context);
            Payments = new PaymentRepository(_context);
            Users = new UserRepository(context);
        }

        public IServiceRepository Services { get; }

        public IClientRepository Clients { get; }

        public IEmployeeRepository Employees { get; }

        public IReservationRepository Reservations { get; }

        public IPaymentRepository Payments { get; }
        public IUserRepository Users { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
