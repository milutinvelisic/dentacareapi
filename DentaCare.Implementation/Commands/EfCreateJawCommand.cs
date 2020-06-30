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
    public class EfCreateJawCommand : ICreateJawCommand
    {
        private readonly DentaCareContext _context;
        private readonly CreateJawValidator _validator;

        public EfCreateJawCommand(DentaCareContext context, CreateJawValidator validator)
        {
            this._context = context;
            this._validator = validator;
        }
        public int Id => 11;

        public string Name => "Create Jaw using EF";

        public void Execute(JawDto request)
        {
            _validator.ValidateAndThrow(request);

            var jaw = new Jaw
            {
                JawName = request.JawName
            };

            _context.Jaws.Add(jaw);
            _context.SaveChanges();
        }
    }
}
