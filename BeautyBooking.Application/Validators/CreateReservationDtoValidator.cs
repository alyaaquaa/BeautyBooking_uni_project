using BeautyBooking.SharedKernel.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.Application.Validators
{
    public class CreateReservationDtoValidator : AbstractValidator<CreateReservationDto>
    {
        public CreateReservationDtoValidator()
        {
            RuleFor(x => x.ClientId)
                .GreaterThan(0).WithMessage("Klient musi zostać wybrany.");

            RuleFor(x => x.EmployeeId)
                .GreaterThan(0).WithMessage("Pracownik musi zostać wybrany.");

            RuleFor(x => x.ServiceIds)
    .NotEmpty().WithMessage("Należy wybrać co najmniej jedną usługę.");

            RuleFor(x => x.ReservationDate)
                .GreaterThan(DateTime.Now).WithMessage("Data rezerwacji musi być przyszła.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status jest wymagany.")
                .MaximumLength(50).WithMessage("Status może mieć maksymalnie 50 znaków.");

            RuleFor(x => x.Notes)
                .MaximumLength(300).WithMessage("Uwagi mogą mieć maksymalnie 300 znaków.");
        }
    }
}
