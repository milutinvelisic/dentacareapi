using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.Exceptions;
using DentaCare.Domain;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Commands
{
    public class EfDeleteEKartonCommand : IDeleteEKartonCommand
    {
        private readonly DentaCareContext _context;

        public EfDeleteEKartonCommand(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 20;

        public string Name => "Delete EKarton using EF";

        public void Execute(int request)
        {
            var eKarton = _context.EKarton.Find(request);

            if (eKarton == null)
            {
                throw new EntityNotFoundException(request, typeof(EKarton));
            }

            eKarton.IsDeleted = true;
            eKarton.DeletedAt = DateTime.UtcNow;
            eKarton.IsActive = false;
            _context.SaveChanges();
        }
    }
}
