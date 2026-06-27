using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.SharedKernel.Dto
{
    public class CreateReservationDto
    {
        public int ClientId { get; set; }

        public int EmployeeId { get; set; }

        public List<int> ServiceIds { get; set; } = new();

        public DateTime ReservationDate { get; set; }

        public string Status { get; set; } = null!;

        public string? Notes { get; set; }
    }
}
