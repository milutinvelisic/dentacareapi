using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentaCare.Application.DataTransfer;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Validators
{
    public class CreateUserValidator: AbstractValidator<UserDto>
    {
        private readonly DentaCareContext _context;

        public CreateUserValidator(DentaCareContext context)
        {
            this._context = context;

            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
