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
    public class EfUpdateAppointmentCommand : IUpdateAppointmentCommand
    {
        private readonly DentaCareContext _context;
        private readonly UpdateAppointmentValidator _validator;

        public EfUpdateAppointmentCommand(DentaCareContext context, UpdateAppointmentValidator validator)
        {
            this._context = context;
            this._validator = validator;
        }
        public int Id => 25;

        public string Name => "Update Appointment using EF";

        public void Execute(AppointmentDto request)
        {
            _validator.ValidateAndThrow(request);

            var appointment = _context.Appointments.Find(request.Id);

            appointment.Email = request.Email;
            appointment.Phone = request.Phone;
            appointment.Date = request.Date;
            appointment.Time = request.Time;
            appointment.ServiceTypeId = request.ServiceTypeId;
            _context.SaveChanges();
        }
    }
}
