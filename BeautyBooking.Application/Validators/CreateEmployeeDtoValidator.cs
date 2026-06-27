using BeautyBooking.SharedKernel.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.Application.Validators
{
    public class CreateEmployeeDtoValidator : AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeDtoValidator()
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
    .NotEmpty()
    .EmailAddress();

            RuleFor(x => x.Position)
                .NotEmpty().WithMessage("Stanowisko jest wymagane.")
                .MaximumLength(100).WithMessage("Stanowisko może mieć maksymalnie 100 znaków.");
        }
    }
}
