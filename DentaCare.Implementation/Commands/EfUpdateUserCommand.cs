using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using DentaCare.Application.Exceptions;
using DentaCare.Domain;
using DentaCare.Implementation.Validators;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Commands
{
    public class EfUpdateUserCommand : IUpdateUserCommand
    {
        private readonly DentaCareContext _context;
        private readonly UpdateUserValidator _validator;

        public EfUpdateUserCommand(DentaCareContext context, UpdateUserValidator validator)
        {
            this._context = context;
            this._validator = validator;
        }
        public int Id => 24;

        public string Name => "Update User using EF";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);

            var user = _context.Users.Find(request.Id);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Password = request.Password;
            user.Phone = request.Phone;
            user.RoleId = request.RoleId;
            _context.SaveChanges();
        }
    }
}
