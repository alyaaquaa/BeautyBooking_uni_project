using BeautyBooking.SharedKernel.Dto;
using FluentValidation;

namespace BeautyBooking.Application.Validators
{
    public class UpdateReservationDtoValidator : AbstractValidator<UpdateReservationDto>
    {
        public UpdateReservationDtoValidator()
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