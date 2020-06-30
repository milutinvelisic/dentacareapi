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
    public class EfUpdateJawSideCommand : IUpdateJawSideCommand
    {
        private readonly DentaCareContext _context;
        private readonly UpdateJawSideValidator _validator;

        public EfUpdateJawSideCommand(DentaCareContext context, UpdateJawSideValidator validator)
        {
            this._context = context;
            this._validator = validator;
        }
        public int Id => 30;

        public string Name => "Update JawSides using EF";

        public void Execute(JawSideDto request)
        {
            _validator.ValidateAndThrow(request);

            var jawSide = _context.JawSides.Find(request.Id);

            jawSide.JawSideName = request.JawSideName;

            _context.SaveChanges();
        }
    }
}
