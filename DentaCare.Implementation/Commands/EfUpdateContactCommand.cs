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
    public class EfUpdateContactCommand : IUpdateContactCommand
    {
        private readonly DentaCareContext _context;
        private readonly UpdateContactValidator _validator;

        public EfUpdateContactCommand(DentaCareContext context, UpdateContactValidator validator)
        {
            this._context = context;
            this._validator = validator;
        }
        public int Id => 26;

        public string Name => "Update Contact using EF";

        public void Execute(ContactDto request)
        {
            _validator.ValidateAndThrow(request);

            var contact = _context.Contact.Find(request.Id);

            contact.Email = request.Email;
            contact.Phone = request.Phone;
            contact.Address = request.Address;
            contact.Fax = request.Fax;
            _context.SaveChanges();
        }
    }
}
