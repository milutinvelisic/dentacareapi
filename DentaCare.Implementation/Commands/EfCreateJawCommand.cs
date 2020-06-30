using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using DentaCare.Domain;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Commands
{
    public class EfCreateJawCommand : ICreateJawCommand
    {
        private readonly DentaCareContext _context;

        public EfCreateJawCommand(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 11;

        public string Name => "Create Jaw using EF";

        public void Execute(JawDto request)
        {
            var jaw = new Jaw
            {
                JawName = request.JawName
            };

            _context.Jaws.Add(jaw);
            _context.SaveChanges();
        }
    }
}
