using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentaCare.Application.DataTransfer;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Validators
{
    public class CreateAppointmentValidator : AbstractValidator<AppointmentDto>
    {
        private readonly DentaCareContext _context;

        public CreateAppointmentValidator(DentaCareContext context)
        {
            this._context = context;

            RuleFor(x => x.FirstNameLastName)
                .NotEmpty()
                .WithMessage("FirstNameLastName is required parameter!");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required parameter!");
            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage("Date is required parameter!");
            RuleFor(x => x.Time)
                .NotEmpty()
                .WithMessage("Time is required parameter!");
            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Phone is required parameter!");
        }
    }
}
