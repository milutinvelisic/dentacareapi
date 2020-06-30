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
    public class EfCreateDentistCommand : ICreateDentistCommand
    {
        private readonly DentaCareContext _context;
        private readonly IMapper _mapper;

        public EfCreateDentistCommand(DentaCareContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public int Id => 9;

        public string Name => "Create Dentist using EF";

        public void Execute(DentistDto request)
        {
            var dentist = new Dentist
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            _context.Dentists.Add(dentist);
            _context.SaveChanges();
        }
    }
}
