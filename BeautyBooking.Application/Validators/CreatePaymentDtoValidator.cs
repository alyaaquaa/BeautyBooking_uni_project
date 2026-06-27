using BeautyBooking.SharedKernel.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.Application.Validators
{
    public class CreatePaymentDtoValidator : AbstractValidator<CreatePaymentDto>
    {
        public CreatePaymentDtoValidator()
        {
            RuleFor(x => x.ReservationId)
                .GreaterThan(0).WithMessage("Rezerwacja musi zostać wybrana.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Kwota musi być większa od 0.");

            RuleFor(x => x.PaymentDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Data płatności nie może być z przyszłości.");

            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("Metoda płatności jest wymagana.")
                .MaximumLength(50).WithMessage("Metoda płatności może mieć maksymalnie 50 znaków.");
        }
    }
}
