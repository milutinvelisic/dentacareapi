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
    public class EfUpdateEKartonCommand : IUpdateEKartonCommand
    {
        private readonly DentaCareContext _context;
        private readonly UpdateEKartonValidator _validator;

        public EfUpdateEKartonCommand(DentaCareContext context, UpdateEKartonValidator validator)
        {
            this._context = context;
            this._validator = validator;
        }
        public int Id => 28;

        public string Name => "Update EKarton using EF";

        public void Execute(EKartonDto request)
        {
            _validator.ValidateAndThrow(request);

            var eKarton = _context.EKarton.Find(request.Id);

            eKarton.Date = request.Date;
            eKarton.UserId = request.UserId;
            eKarton.JawJawSideToothId = request.JawJawSideToothId;
            eKarton.Price = request.Price;
            eKarton.ServiceTypeId = request.ServiceTypeId;
            _context.SaveChanges();
        }
    }
}
