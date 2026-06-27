using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.SharedKernel.Dto
{

    public class CreateEmployeeDto
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        public string Position { get; set; } = null!;
    }
}
