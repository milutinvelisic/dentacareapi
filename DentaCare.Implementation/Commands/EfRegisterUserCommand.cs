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
    public class EfRegisterUserCommand : IRegisterUserCommand
    {
        private readonly DentaCareContext _context;
        private readonly RegisterUserValidator _validator;

        public EfRegisterUserCommand(DentaCareContext context, RegisterUserValidator validator)
        {
            this._context = context;
            this._validator = validator;
        }
        public int Id => 5;

        public string Name => "Register user using EF";

        public void Execute(RegisterUserDto request)
        {
            _validator.ValidateAndThrow(request);

            _context.Users.Add(new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Password = request.Password,
                RoleId = 13
            });

            _context.SaveChanges();
        }
    }
}
