using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using DentaCare.Domain;
using DentaCare.Implementation.Validators;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Commands
{
    public class EfCreateContactCommand : ICreateContactCommand
    {
        private readonly DentaCareContext _context;
        private readonly CreateContactValidator _validator;

        public EfCreateContactCommand(DentaCareContext context, CreateContactValidator validator)
        {
            this._context = context;
            this._validator = validator;
        }
        public int Id => 8;

        public string Name => "Create Contact using EF";

        public void Execute(ContactDto request)
        {
            _validator.ValidateAndThrow(request);

            var contact = new Contact
            {
                Address = request.Address,
                Phone = request.Phone,
                Fax = request.Fax,
                Email = request.Email
            };

            _context.Contact.Add(contact);
            _context.SaveChanges();
        }
    }
}
