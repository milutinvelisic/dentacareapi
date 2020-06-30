using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;

namespace DentaCare.Implementation.Commands
{
    public class EfCreateEKartonCommand : ICreateEKartonCommand
    {
        public int Id => 6;

        public string Name => "Create EKarton with Ef";

        public void Execute(EKartonDto request)
        {
            throw new NotImplementedException();
        }
    }
}
