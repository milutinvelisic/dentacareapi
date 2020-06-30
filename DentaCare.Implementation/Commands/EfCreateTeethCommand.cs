using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using DentaCare.Domain;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Commands
{
    public class EfCreateTeethCommand : ICreateToothCommand
    {
        private readonly DentaCareContext _context;

        public EfCreateTeethCommand(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 14;

        public string Name => "Creating tooth using EF";

        public void Execute(TeethDto request)
        {
            var tooth = new Teeth
            {
                ToothNumber = request.ToothNumber
            };

            _context.Teeth.Add(tooth);
            _context.SaveChanges();
        }
    }
}
