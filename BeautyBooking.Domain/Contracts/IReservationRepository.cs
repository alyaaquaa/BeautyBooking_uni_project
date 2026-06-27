using BeautyBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.Domain.Contracts
{
    public interface IReservationRepository : IRepository<Reservation>
    {
    }
}
