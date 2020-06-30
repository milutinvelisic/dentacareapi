using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.DataTransfer;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Validators
{
    public class UpdateEKartonValidator : AbstractValidator<EKartonDto>
    {
        private readonly DentaCareContext _context;

        public UpdateEKartonValidator(DentaCareContext context)
        {
            this._context = context;

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Price is required parameter!");
            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage("Date is required parameter!");
        }
    }
}
