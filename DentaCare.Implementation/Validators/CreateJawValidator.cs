using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.DataTransfer;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Validators
{
    public class CreateJawValidator : AbstractValidator<JawDto>
    {
        private readonly DentaCareContext _context;

        public CreateJawValidator(DentaCareContext context)
        {
            this._context = context;

            RuleFor(x => x.JawName)
                .NotEmpty()
                .WithMessage("JawName is required parameter!");
        }
    }
}
