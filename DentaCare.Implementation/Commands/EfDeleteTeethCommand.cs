using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.Exceptions;
using DentaCare.Domain;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Commands
{
    public class EfDeleteTeethCommand : IDeleteToothCommand
    {
        private readonly DentaCareContext _context;

        public EfDeleteTeethCommand(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 23;

        public string Name => "Delete Teeth using EF";

        public void Execute(int request)
        {
            var teeth = _context.Teeth.Find(request);

            if (teeth == null)
            {
                throw new EntityNotFoundException(request, typeof(Teeth));
            }

            teeth.IsDeleted = true;
            teeth.DeletedAt = DateTime.UtcNow;
            teeth.IsActive = false;
            _context.SaveChanges();
        }
    }
}
