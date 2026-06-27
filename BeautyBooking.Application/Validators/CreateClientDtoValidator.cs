using BeautyBooking.SharedKernel.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.Application.Validators
{
    public class CreateClientDtoValidator : AbstractValidator<CreateClientDto>
    {
        public CreateClientDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Imię jest wymagane.")
                .MinimumLength(2).WithMessage("Imię musi mieć co najmniej 2 znaki.")
                .MaximumLength(50).WithMessage("Imię może mieć maksymalnie 50 znaków.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Nazwisko jest wymagane.")
                .MinimumLength(2).WithMessage("Nazwisko musi mieć co najmniej 2 znaki.")
                .MaximumLength(50).WithMessage("Nazwisko może mieć maksymalnie 50 znaków.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email jest wymagany.")
                .EmailAddress().WithMessage("Podaj poprawny adres email.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Numer telefonu jest wymagany.")
                .MinimumLength(9).WithMessage("Numer telefonu musi mieć co najmniej 9 cyfr.")
                .MaximumLength(15).WithMessage("Numer telefonu może mieć maksymalnie 15 znaków.");
        }
    }
}
