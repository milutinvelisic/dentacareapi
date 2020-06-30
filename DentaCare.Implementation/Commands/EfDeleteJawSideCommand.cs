using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.Exceptions;
using DentaCare.Domain;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Commands
{
    public class EfDeleteJawSideCommand : IDeleteJawSideCommand
    {
        private readonly DentaCareContext _context;

        public EfDeleteJawSideCommand(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 22;

        public string Name => "Delete JawSide using EF";

        public void Execute(int request)
        {
            var jawSide = _context.JawSides.Find(request);

            if (jawSide == null)
            {
                throw new EntityNotFoundException(request, typeof(JawSide));
            }

            jawSide.IsDeleted = true;
            jawSide.DeletedAt = DateTime.UtcNow;
            jawSide.IsActive = false;
            _context.SaveChanges();
        }
    }
}
