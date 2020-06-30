using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using DentaCare.Application.Exceptions;
using DentaCare.Domain;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Commands
{
    public class EfDeleteRoleCommand : IDeleteRoleCommand
    {
        private readonly DentaCareContext _context;

        public EfDeleteRoleCommand(DentaCareContext context)
        {
            this._context = context;
        }

        public int Id => 3;

        public string Name => "Delete role using EF.";

        public void Execute(int id)
        {
            var role = _context.Roles.Find(id);

            if (role == null)
            {
                throw new EntityNotFoundException(id, typeof(Role));
            }

            _context.Roles.Remove(role);
            _context.SaveChanges();
        }
    }
}
