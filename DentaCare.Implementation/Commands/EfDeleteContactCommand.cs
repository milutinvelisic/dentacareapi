using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.Exceptions;
using DentaCare.Domain;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Commands
{
    public class EfDeleteContactCommand : IDeleteContactCommand
    {
        private readonly DentaCareContext _context;

        public EfDeleteContactCommand(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 18;

        public string Name => "Delete Contact using EF";

        public void Execute(int request)
        {
            var contact = _context.Contact.Find(request);

            if (contact == null)
            {
                throw new EntityNotFoundException(request, typeof(Contact));
            }

            contact.IsDeleted = true;
            contact.DeletedAt = DateTime.UtcNow;
            contact.IsActive = false;
            _context.SaveChanges();
        }
    }
}
