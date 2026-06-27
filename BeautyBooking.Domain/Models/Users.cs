namespace BeautyBooking.Domain.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Role { get; set; } = null!; // Employee albo Client

        public int? ClientId { get; set; }

        public Client? Client { get; set; }

        public int? EmployeeId { get; set; }

        public Employee? Employee { get; set; }
    }
}