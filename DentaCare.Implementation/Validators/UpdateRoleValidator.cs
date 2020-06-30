using DentaCare.Application.DataTransfer;
using DentaCareDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentaCare.Implementation.Validators
{
    public class UpdateRoleValidator : AbstractValidator<RoleDto>
    {
        private readonly DentaCareContext _context;

        public UpdateRoleValidator(DentaCareContext context)
        {
            this._context = context;

            RuleFor(x => x.RoleName)
                .NotEmpty()
                .WithMessage("RoleName is required parameter!")
                .Must((dto, name) => !_context.Roles.Any(x => x.RoleName == name && x.Id == dto.Id))
                .WithMessage(p => $"RoleName with same name already exists!");
        }

    }// Dependency Injection = prilikom kreiranja objekta odredjene klase, kroz konstruktor ce joj biti ubaceno sve sto joj je neophodno da ona radi
}