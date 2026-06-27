using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.SharedKernel.Dto
{
    public class LoggedUserDto
    {
        public int UserId { get; set; }

        public string Email { get; set; } = null!;

        public string Role { get; set; } = null!;

        public int? ClientId { get; set; }

        public int? EmployeeId { get; set; }

        public string FullName { get; set; } = null!;
    }
}