using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.DataTransfer;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Validators
{
    public class UpdateDentistValidator : AbstractValidator<DentistDto>
    {
        private readonly DentaCareContext _context;

        public UpdateDentistValidator(DentaCareContext context)
        {
            this._context = context;

            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3);
        }
    }
}
