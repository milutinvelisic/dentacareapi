using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using DentaCare.Domain;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Commands
{
    public class EfCreateJawJawSideToothCommand : ICreateJawJawSideToothCommand
    {
        private readonly DentaCareContext _context;

        public EfCreateJawJawSideToothCommand(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 13;

        public string Name => "Create JawSideTooth using EF";

        public void Execute(JawJawSideToothDto request)
        {
            var jawSideTooth = new JawJawSideTooth
            {
                JawId = request.JawId,
                JawSideId = request.ToothId,
                ToothId = request.ToothId
            };

            _context.JawJawSideTeeth.Add(jawSideTooth);
            _context.SaveChanges();
        }
    }
}
