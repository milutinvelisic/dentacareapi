using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.DataTransfer;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Validators
{
    public class UpdateContactValidator : AbstractValidator<ContactDto>
    {
        private readonly DentaCareContext _context;

        public UpdateContactValidator(DentaCareContext context)
        {
            this._context = context;

            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
        }
    }
}
