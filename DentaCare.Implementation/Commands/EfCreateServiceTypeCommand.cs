using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using DentaCare.Domain;
using DentaCare.Implementation.Validators;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Commands
{
    public class EfCreateServiceTypeCommand : ICreateServiceTypeCommand
    {
        private readonly DentaCareContext _context;
        private readonly CreateUserValidator _validator;

        public EfCreateServiceTypeCommand(DentaCareContext context, CreateUserValidator validator)
        {
            this._context = context;
            this._validator = validator;
        }
        public int Id => 15;

        public string Name => "Create ServiceType using EF";

        public void Execute(ServiceTypeDto request)
        {
            //_validator.ValidateAndThrow(request);

            _context.ServiceTypes.Add(new ServiceType
            {
                ServiceName = request.ServiceName,
                ServiceDescription = request.ServiceDescription,
                ServicePrice = request.ServicePrice
            });

            _context.SaveChanges();
        }
    }
}
