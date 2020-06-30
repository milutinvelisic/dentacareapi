using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using DentaCare.Domain;
using DentaCare.Implementation.Validators;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Commands
{
    public class EfCreateTeethCommand : ICreateToothCommand
    {
        private readonly DentaCareContext _context;
        private readonly CreateTeethValidator _validator;

        public EfCreateTeethCommand(DentaCareContext context, CreateTeethValidator validator)
        {
            this._context = context;
            this._validator = validator;
        }
        public int Id => 14;

        public string Name => "Creating tooth using EF";

        public void Execute(TeethDto request)
        {
            _validator.ValidateAndThrow(request);

            var tooth = new Teeth
            {
                ToothNumber = request.ToothNumber
            };

            _context.Teeth.Add(tooth);
            _context.SaveChanges();
        }
    }
}
