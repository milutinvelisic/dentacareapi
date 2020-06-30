using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;
using DentaCareDataAccess;
using DentaCare.Domain;
using DentaCare.Implementation.Validators;
using FluentValidation;

namespace DentaCare.Implementation.Commands
{
    public class EfCreateRoleCommand : ICreateRoleCommand
    {

        private readonly DentaCareContext _context;

        private readonly CreateRoleValidator _validator;

        public EfCreateRoleCommand(DentaCareContext context,
            CreateRoleValidator validator)
        {
            this._context = context;
            this._validator = validator;
        }


        public int Id => 1;

        public string Name => "Creating role using EF";

        public void Execute(RoleDto request)
        {
            _validator.ValidateAndThrow(request);

            var role = new Role
            {
                RoleName = request.RoleName
            };

            _context.Roles.Add(role);
            _context.SaveChanges();
        }
    }
}
