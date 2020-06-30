using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.DataTransfer;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Validators
{
    public class UpdateJawValidator : AbstractValidator<JawDto>
    {
        private readonly DentaCareContext _context;

        public UpdateJawValidator(DentaCareContext context)
        {
            this._context = context;

            RuleFor(x => x.JawName).NotEmpty().MinimumLength(2);
        }
    }
}
