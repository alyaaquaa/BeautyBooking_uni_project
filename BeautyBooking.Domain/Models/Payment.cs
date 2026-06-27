using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.Domain.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; } = null!;

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string PaymentMethod { get; set; } = null!;

        public bool IsPaid { get; set; }
    }
}
