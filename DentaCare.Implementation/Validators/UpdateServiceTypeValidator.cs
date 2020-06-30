using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.DataTransfer;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Validators
{
    public class UpdateServiceTypeValidator : AbstractValidator<ServiceTypeDto>
    {
        private readonly DentaCareContext _context;

        public UpdateServiceTypeValidator(DentaCareContext context)
        {
            this._context = context;

            RuleFor(x => x.ServiceDescription).NotEmpty().MinimumLength(3);
            RuleFor(x => x.ServiceName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.ServicePrice).NotEmpty();
        }
    }
}
