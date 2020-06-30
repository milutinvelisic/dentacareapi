using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.DataTransfer;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Validators
{
    public class CreateContactValidator : AbstractValidator<ContactDto>
    {
        private readonly DentaCareContext _context;

        public CreateContactValidator(DentaCareContext context)
        {
            this._context = context;

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Address is required parameter!");
            RuleFor(x => x.Fax)
                .NotEmpty()
                .WithMessage("Fax is required parameter!");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required parameter!");
            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Phone is required parameter!");
        }
    }
}
