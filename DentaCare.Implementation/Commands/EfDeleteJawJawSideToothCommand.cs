using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.Exceptions;
using DentaCare.Domain;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Commands
{
    public class EfDeleteJawJawSideToothCommand : IDeleteJawJawSideToothCommand
    {
        private readonly DentaCareContext _context;

        public EfDeleteJawJawSideToothCommand(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 23;

        public string Name => "Delete JawSideTooth using EF";

        public void Execute(int request)
        {
            var jawSideTooth = _context.JawSides.Find(request);

            if (jawSideTooth == null)
            {
                throw new EntityNotFoundException(request, typeof(JawSide));
            }

            jawSideTooth.IsDeleted = true;
            jawSideTooth.DeletedAt = DateTime.UtcNow;
            jawSideTooth.IsActive = false;
            _context.SaveChanges();
        }
    }
}
