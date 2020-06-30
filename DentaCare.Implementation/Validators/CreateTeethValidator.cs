using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.DataTransfer;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Validators
{
    public class CreateTeethValidator : AbstractValidator<TeethDto>
    {
        private readonly DentaCareContext _context;

        public CreateTeethValidator(DentaCareContext context)
        {
            this._context = context;

            RuleFor(x => x.ToothNumber)
                .NotEmpty()
                .WithMessage("ToothNumber is required parameter!");
        }
    }
}
