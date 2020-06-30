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
    public class EfUpdateRoleCommand : IUpdateRoleCommand
    {
        private readonly DentaCareContext _context;
        private readonly UpdateRoleValidator _validator;

        public EfUpdateRoleCommand(DentaCareContext context, UpdateRoleValidator validator)
        {
            this._context = context;
            this._validator = validator;
        }
        public int Id => 32;

        public string Name => "Update Roles using EF";

        public void Execute(RoleDto request)
        {
            _validator.ValidateAndThrow(request);

            var role = _context.Roles.Find(request.Id);

            role.RoleName = request.RoleName;

            _context.SaveChanges();
        }
    }
}
