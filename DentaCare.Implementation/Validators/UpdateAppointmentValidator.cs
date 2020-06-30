using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentaCare.Application.DataTransfer;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Validators
{
    public class UpdateAppointmentValidator : AbstractValidator<AppointmentDto>
    {
        private readonly DentaCareContext _context;

        public UpdateAppointmentValidator(DentaCareContext context)
        {
            this._context = context;

            RuleFor(x => x.FirstNameLastName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Email).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.Time).NotEmpty();
        }
    }
}
