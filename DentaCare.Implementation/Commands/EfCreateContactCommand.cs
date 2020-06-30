using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using DentaCare.Domain;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Commands
{
    public class EfCreateContactCommand : ICreateContactCommand
    {
        private readonly DentaCareContext _context;
        private readonly IMapper _mapper;

        public EfCreateContactCommand(DentaCareContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public int Id => 8;

        public string Name => "Create Contact using EF";

        public void Execute(ContactDto request)
        {
            var contact = new Contact
            {
                Address = request.Address,
                Phone = request.Phone,
                Fax = request.Fax,
                Email = request.Email
            };

            _context.Contact.Add(contact);
            _context.SaveChanges();
        }
    }
}
