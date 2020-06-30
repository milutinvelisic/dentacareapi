using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.Exceptions;
using DentaCare.Domain;
using DentaCare.Implementation.Validators;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Commands
{
    public class EfDeleteDentistCommand : IDeleteDentistCommand
    {
        private readonly DentaCareContext _context;
        private readonly CreateDentistValidator _validator;

        public EfDeleteDentistCommand(DentaCareContext context, CreateDentistValidator validator)
        {
            this._context = context;
            this._validator = validator;
        }
        public int Id => 19;

        public string Name => "Delete Dentist using EF";

        public void Execute(int request)
        {
            var dentist = _context.Dentists.Find(request);

            if (dentist == null)
            {
                throw new EntityNotFoundException(request, typeof(Dentist));
            }

            dentist.IsDeleted = true;
            dentist.DeletedAt = DateTime.UtcNow;
            dentist.IsActive = false;
            _context.SaveChanges();
        }
    }
}
