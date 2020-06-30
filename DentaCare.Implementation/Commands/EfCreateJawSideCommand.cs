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
    public class EfCreateJawSideCommand : ICreateJawSideCommand
    {
        private readonly DentaCareContext _context;
        private readonly CreateJawSideValidator _validator;

        public EfCreateJawSideCommand(DentaCareContext context, CreateJawSideValidator validator)
        {
            this._context = context;
            this._validator = validator;
        }
        public int Id => 12;

        public string Name => "Create JawSide using EF";

        public void Execute(JawSideDto request)
        {
            _validator.ValidateAndThrow(request);

            var jawSide = new JawSide
            {
                JawSideName = request.JawSideName
            };

            _context.JawSides.Add(jawSide);
            _context.SaveChanges();
        }
    }
}
