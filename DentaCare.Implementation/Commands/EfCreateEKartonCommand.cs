using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using DentaCare.Domain;
using DentaCare.Implementation.Validators;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Commands
{
    public class EfCreateEKartonCommand : ICreateEKartonCommand
    {
        private readonly DentaCareContext _context;
        private readonly CreateEKartonValidator _validator;

        public EfCreateEKartonCommand(DentaCareContext context, CreateEKartonValidator validator)
        {
            this._context = context;
            this._validator = validator;
        }
        public int Id => 10;

        public string Name => "Create EKarton with Ef";

        public void Execute(EKartonDto request)
        {
            _validator.ValidateAndThrow(request);

            var ekarton = new EKarton
            {
                Date = request.Date,
                Price = request.Price
            };

            _context.EKarton.Add(ekarton);
            _context.SaveChanges();
        }
    }
}
