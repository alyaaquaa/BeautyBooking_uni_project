using System.ComponentModel.DataAnnotations;

public class LoginDto
{
    [Required(ErrorMessage = "Podaj adres e-mail.")]
    [EmailAddress(ErrorMessage = "Podaj poprawny adres e-mail.")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Podaj hasło.")]
    public string Password { get; set; } = "";
}