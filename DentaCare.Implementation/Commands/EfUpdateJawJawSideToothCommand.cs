using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Commands
{
    public class EfUpdateJawJawSideToothCommand : IUpdateJawJawSideToothCommand
    {
        private readonly DentaCareContext _context;

        public EfUpdateJawJawSideToothCommand(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 31;

        public string Name => "Update JawSideTeeth using EF";

        public void Execute(JawJawSideToothDto request)
        {
            

            var jawSide = _context.JawJawSideTeeth.Find(request.Id);

            jawSide.JawId = request.JawId;
            jawSide.JawSideId = request.JawSideId;
            jawSide.ToothId = request.ToothId;

            _context.SaveChanges();
        }
    }
}
