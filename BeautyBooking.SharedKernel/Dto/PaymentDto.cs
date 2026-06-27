namespace BeautyBooking.SharedKernel.Dto
{
    public class PaymentDto
    {
        public int Id { get; set; }

        public int ReservationId { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string PaymentMethod { get; set; } = null!;

        public bool IsPaid { get; set; }
    }
}