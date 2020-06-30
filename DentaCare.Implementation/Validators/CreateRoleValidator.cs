using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentaCare.Application.DataTransfer;
using DentaCareDataAccess;
using FluentValidation;

namespace DentaCare.Implementation.Validators
{
    public class CreateRoleValidator : AbstractValidator<RoleDto>
    {
        private readonly DentaCareContext _context;
        
        public CreateRoleValidator(DentaCareContext context)
        {
            this._context = context;

            RuleFor(x => x.RoleName)
                .NotEmpty()
                .WithMessage("RoleName is required parameter!")
                .Must(n => !_context.Roles.Any(x => x.RoleName == n))
                .WithMessage(p => $"RoleName with same name already exists!");
        }

    }// Dependency Injection = prilikom kreiranja objekta odredjene klase, kroz konstruktor ce joj biti ubaceno sve sto joj je neophodno da ona radi
}
