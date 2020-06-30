using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.Exceptions;
using DentaCare.Domain;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Commands
{
    public class EfDeleteAppointmentCommand : IDeleteAppointmentCommand
    {
        private readonly DentaCareContext _context;

        public EfDeleteAppointmentCommand(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 16;

        public string Name => "Delete Appointment using EF";

        public void Execute(int request)
        {
            var appointment = _context.Appointments.Find(request);

            if (appointment == null)
            {
                throw new EntityNotFoundException(request, typeof(Appointment));
            }

            appointment.IsDeleted = true;
            appointment.DeletedAt = DateTime.UtcNow;
            appointment.IsActive = false;
            _context.SaveChanges();
        }
    }
}
