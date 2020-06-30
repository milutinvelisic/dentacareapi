using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using DentaCare.Domain;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Commands
{
    public class EfCreateJawSideCommand : ICreateJawSideCommand
    {
        private readonly DentaCareContext _context;

        public EfCreateJawSideCommand(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 12;

        public string Name => "Create JawSide using EF";

        public void Execute(JawSideDto request)
        {
            var jawSide = new JawSide
            {
                JawSideName = request.JawSideName
            };

            _context.JawSides.Add(jawSide);
            _context.SaveChanges();
        }
    }
}
