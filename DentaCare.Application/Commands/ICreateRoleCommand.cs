using DentaCare.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Application.Commands
{
    public interface ICreateRoleCommand : ICommand<RoleDto>
    {
    }
}
