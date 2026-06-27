using BeautyBooking.Domain.Contracts;
using BeautyBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.Infrastructure.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(BeautyBookingDbContext context)
            : base(context)
        {
        }
    }
}
