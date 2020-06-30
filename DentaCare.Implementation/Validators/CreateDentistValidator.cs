using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.DataTransfer;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Validators
{
    public class CreateDentistValidator : AbstractValidator<DentistDto>
    {
        private readonly DentaCareContext _context;

        public CreateDentistValidator(DentaCareContext context)
        {
            this._context = context;

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("FirstName is required parameter!");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("LastName is required parameter!");
        }
    }
}
