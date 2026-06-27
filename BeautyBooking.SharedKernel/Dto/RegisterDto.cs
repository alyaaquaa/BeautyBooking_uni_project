using System.ComponentModel.DataAnnotations;

namespace BeautyBooking.SharedKernel.Dto
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Wybierz rolę.")]
        public string Role { get; set; } = "";

        [Required(ErrorMessage = "Podaj imię.")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "Podaj nazwisko.")]
        public string LastName { get; set; } = "";

        [Required(ErrorMessage = "Podaj adres e-mail.")]
        [EmailAddress(ErrorMessage = "Podaj poprawny adres e-mail.")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Podaj hasło.")]
        [MinLength(6, ErrorMessage = "Hasło musi mieć co najmniej 6 znaków.")]
        public string Password { get; set; } = "";

        [Phone(ErrorMessage = "Podaj poprawny numer telefonu.")]
        public string? PhoneNumber { get; set; }

        public string? Position { get; set; }
    }
}