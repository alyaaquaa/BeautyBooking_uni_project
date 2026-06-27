using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.Domain.Contracts
{
    public interface IBeautyBookingUnitOfWork
    {
        IServiceRepository Services { get; }
        IClientRepository Clients { get; }

        IEmployeeRepository Employees { get; }

        IReservationRepository Reservations { get; }

        IPaymentRepository Payments { get; }
        IUserRepository Users { get; }

        Task<int> SaveChangesAsync();
    }
}
