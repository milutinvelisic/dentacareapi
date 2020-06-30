using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.DataTransfer;

namespace DentaCare.Application.Commands
{
    public interface IUpdateContactCommand : ICommand<ContactDto>
    {
    }
}
