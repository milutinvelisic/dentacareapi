using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using DentaCare.Application.Email;
using DentaCare.Domain;
using DentaCare.Implementation.Validators;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Commands
{
    public class EfCreateUserCommand : ICreateUserCommand
    {
        private readonly DentaCareContext _context;
        private readonly CreateUserValidator _validator;
        private readonly IEmailSender _sender;

        public EfCreateUserCommand(DentaCareContext context, CreateUserValidator validator, IEmailSender sender)
        {
            this._context = context;
            this._validator = validator;
            this._sender = sender;
        }
        public int Id => 5;

        public string Name => "Register user using EF";

        public void Execute(UserDto request)
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

            _sender.Send(new SendEmailDto
            {
                Content = "<h1>Successfull registration1</h1>",
                SendTo = request.Email,
                Subject = "Registration"
            });

            _context.SaveChanges();
        }
    }
}
