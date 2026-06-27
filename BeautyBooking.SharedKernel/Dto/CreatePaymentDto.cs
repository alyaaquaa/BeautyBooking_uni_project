using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.SharedKernel.Dto
{
    public class CreatePaymentDto
    {
        public int ReservationId { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string PaymentMethod { get; set; } = null!;

        public bool IsPaid { get; set; }
    }
}
