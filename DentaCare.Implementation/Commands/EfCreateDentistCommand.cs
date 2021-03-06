﻿using System;
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
    public class EfCreateDentistCommand : ICreateDentistCommand
    {
        private readonly DentaCareContext _context;
        private readonly CreateDentistValidator _validator;

        public EfCreateDentistCommand(DentaCareContext context, CreateDentistValidator validator)
        {
            this._context = context;
            this._validator = validator;
        }
        public int Id => 9;

        public string Name => "Create Dentist using EF";

        public void Execute(DentistDto request)
        {
            _validator.ValidateAndThrow(request);

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
