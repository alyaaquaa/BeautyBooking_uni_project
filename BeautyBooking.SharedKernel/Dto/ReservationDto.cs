using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.SharedKernel.Dto
{
    public class ReservationDto
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime ReservationDate { get; set; }

        public string Status { get; set; } = null!;

        public string? Notes { get; set; }

        public List<int> ServiceIds { get; set; } = new();

        public List<string> ServiceNames { get; set; } = new();
    }
}