using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.Domain.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; } = null!;

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = null!;

        public DateTime ReservationDate { get; set; }

        public string Status { get; set; } = null!;

        public string? Notes { get; set; }

        public Payment? Payment { get; set; }

        public ICollection<ReservationItem> ReservationItems { get; set; } = new List<ReservationItem>();
    }
}
