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
    public class EfUpdateTeethCommand : IUpdateToothCommand
    {
        private readonly DentaCareContext _context;
        private readonly UpdateTeethValidator _validator;

        public EfUpdateTeethCommand(DentaCareContext context, UpdateTeethValidator validator)
        {
            this._context = context;
            this._validator = validator;
        }
        public int Id => 34;

        public string Name => "Update ServiceTypes using EF";

        public void Execute(TeethDto request)
        {
            _validator.ValidateAndThrow(request);

            var teeth = _context.Teeth.Find(request.Id);

            teeth.ToothNumber = request.ToothNumber;

            _context.SaveChanges();
        }
    }
}
