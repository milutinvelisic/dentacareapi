using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using DentaCare.Implementation.Validators;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Commands
{
    public class EfUpdateServiceTypeCommand : IUpdateServiceTypeCommand
    {
        private readonly DentaCareContext _context;
        private readonly UpdateServiceTypeValidator _validator;

        public EfUpdateServiceTypeCommand(DentaCareContext context, UpdateServiceTypeValidator validator)
        {
            this._context = context;
            this._validator = validator;
        }
        public int Id => 33;

        public string Name => "Update ServiceTypes using EF";

        public void Execute(ServiceTypeDto request)
        {
            _validator.ValidateAndThrow(request);

            var service = _context.ServiceTypes.Find(request.Id);

            service.ServiceName = request.ServiceName;
            service.ServiceDescription = request.ServiceDescription;
            service.ServicePrice = request.ServicePrice;

            _context.SaveChanges();
        }
    }
}
