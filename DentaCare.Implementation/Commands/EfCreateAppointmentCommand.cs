using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using DentaCare.Domain;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Commands
{
    public class EfCreateAppointmentCommand : ICreateAppointmentCommand
    {
        private readonly DentaCareContext _context;
        private readonly IMapper _mapper;

        public EfCreateAppointmentCommand(DentaCareContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public int Id => 7;

        public string Name => "Create Appointment using EF";

        public void Execute(AppointmentDto request)
        {
            var appointment = new Appointment
            {
                FirstNameLastName = request.FirstNameLastName,
                Email = request.Email,
                Phone = request.Phone,
                Date = DateTime.UtcNow,
                Time = request.Time
            };

            //_mapper.Map<Appointment>(request);

            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }
    }
}
