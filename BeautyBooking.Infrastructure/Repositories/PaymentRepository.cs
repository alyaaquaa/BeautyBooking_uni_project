using BeautyBooking.Domain.Contracts;
using BeautyBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.Infrastructure.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(BeautyBookingDbContext context)
            : base(context)
        {
        }
    }
}
