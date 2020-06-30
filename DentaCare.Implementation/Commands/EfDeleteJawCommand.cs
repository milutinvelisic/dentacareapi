using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.Exceptions;
using DentaCare.Domain;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Commands
{
    public class EfDeleteJawCommand : IDeleteJawCommand
    {
        private readonly DentaCareContext _context;

        public EfDeleteJawCommand(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 21;

        public string Name => "Delete Jaw using EF";

        public void Execute(int request)
        {
            var jaw = _context.Jaws.Find(request);

            if (jaw == null)
            {
                throw new EntityNotFoundException(request, typeof(Jaw));
            }

            jaw.IsDeleted = true;
            jaw.DeletedAt = DateTime.UtcNow;
            jaw.IsActive = false;
            _context.SaveChanges();
        }
    }
}
