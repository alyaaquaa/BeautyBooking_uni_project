using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.Domain.Models
{
    public class ReservationItem
    {
        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; } = null!;

        public int ServiceId { get; set; }

        public Service Service { get; set; } = null!;
    }
}
