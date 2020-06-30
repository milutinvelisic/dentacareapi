using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.DataTransfer;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Validators
{
    public class CreateJawSideValidator : AbstractValidator<JawSideDto>
    {
        private readonly DentaCareContext _context;

        public CreateJawSideValidator(DentaCareContext context)
        {
            this._context = context;

            RuleFor(x => x.JawSideName)
                .NotEmpty()
                .WithMessage("JawSideName is required parameter!");
        }
    }
}
