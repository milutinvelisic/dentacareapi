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
    public class EfUpdateDentistCommand : IUpdateDentistCommand
    {
        private readonly DentaCareContext _context;
        private readonly UpdateDentistValidator _validator;

        public EfUpdateDentistCommand(DentaCareContext context, UpdateDentistValidator validator)
        {
            this._context = context;
            this._validator = validator;
        }
        public int Id => 27;

        public string Name => "Update Dentist using EF";

        public void Execute(DentistDto request)
        {
            _validator.ValidateAndThrow(request);

            var dentist = _context.Dentists.Find(request.Id);

            dentist.FirstName = request.FirstName;
            dentist.LastName = request.LastName;
            _context.SaveChanges();
        }
    }
}
