using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.DataTransfer;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Validators
{
    public class CreateServiceTypeValidator : AbstractValidator<ServiceTypeDto>
    {
        private readonly DentaCareContext _context;

        public CreateServiceTypeValidator(DentaCareContext context)
        {
            this._context = context;

            RuleFor(x => x.ServiceDescription)
                .NotEmpty()
                .WithMessage("ServiceDescription is required parameter!");
            RuleFor(x => x.ServiceName)
                .NotEmpty()
                .WithMessage("ServiceName is required parameter!");
            RuleFor(x => x.ServicePrice)
                .NotEmpty()
                .WithMessage("ServicePrice is required parameter!");
        }
    }
}
