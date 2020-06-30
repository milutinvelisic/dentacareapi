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
    public class EfUpdateJawCommand : IUpdateJawCommand
    {
        private readonly DentaCareContext _context;
        private readonly UpdateJawValidator _validator;

        public EfUpdateJawCommand(DentaCareContext context, UpdateJawValidator validator)
        {
            this._context = context;
            this._validator = validator;
        }
        public int Id => 29;

        public string Name => "Update Jaws using EF";

        public void Execute(JawDto request)
        {
            _validator.ValidateAndThrow(request);

            var jaw = _context.Jaws.Find(request.Id);

            jaw.JawName = request.JawName;
            _context.SaveChanges();
        }
    }
}
