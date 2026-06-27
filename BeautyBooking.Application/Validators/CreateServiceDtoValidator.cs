using BeautyBooking.SharedKernel.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.Application.Validators
{
    public class CreateServiceDtoValidator : AbstractValidator<CreateServiceDto>
    {
        public CreateServiceDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nazwa usługi jest wymagana.")
                .MinimumLength(2).WithMessage("Nazwa musi mieć co najmniej 2 znaki.")
                .MaximumLength(50).WithMessage("Nazwa może mieć maksymalnie 50 znaków.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Opis usługi jest wymagany.")
                .MaximumLength(300).WithMessage("Opis może mieć maksymalnie 300 znaków.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Cena musi być większa od 0.");

            RuleFor(x => x.DurationMinutes)
                .GreaterThan(0).WithMessage("Czas trwania musi być większy od 0.");
        }
    }
}
