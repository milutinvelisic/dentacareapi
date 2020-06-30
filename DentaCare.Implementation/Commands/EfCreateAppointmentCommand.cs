using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using DentaCare.Domain;
using DentaCare.Implementation.Validators;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Commands
{
    public class EfCreateAppointmentCommand : ICreateAppointmentCommand
    {
        private readonly DentaCareContext _context;
        private readonly IMapper _mapper;
        private readonly CreateAppointmentValidator _validator;

        public EfCreateAppointmentCommand(DentaCareContext context, IMapper mapper, CreateAppointmentValidator validator)
        {
            this._context = context;
            this._mapper = mapper;
            this._validator = validator;
        }
        public int Id => 7;

        public string Name => "Create Appointment using EF";

        public void Execute(AppointmentDto request)
        {
            _validator.ValidateAndThrow(request);

            var appointment = new Appointment
            {
                FirstNameLastName = request.FirstNameLastName,
                Email = request.Email,
                Phone = request.Phone,
                Date = DateTime.UtcNow,
                Time = request.Time
            };

            //var appointment = _mapper.Map<Appointment>(request);

            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }
    }
}
