using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.Exceptions;
using DentaCare.Domain;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Commands
{
    public class EfDeleteServiceTypeCommand : IDeleteServiceTypeCommand
    {
        private readonly DentaCareContext _context;

        public EfDeleteServiceTypeCommand(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 23;

        public string Name => "Delete ServiceType using EF";

        public void Execute(int request)
        {
            var serviceType = _context.ServiceTypes.Find(request);

            if (serviceType == null)
            {
                throw new EntityNotFoundException(request, typeof(ServiceType));
            }

            serviceType.IsDeleted = true;
            serviceType.DeletedAt = DateTime.UtcNow;
            serviceType.IsActive = false;
            _context.SaveChanges();
        }
    }
}
