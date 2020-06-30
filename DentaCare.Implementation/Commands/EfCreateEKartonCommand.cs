﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using DentaCare.Domain;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Commands
{
    public class EfCreateEKartonCommand : ICreateEKartonCommand
    {
        private readonly DentaCareContext _context;
        private readonly IMapper _mapper;

        public EfCreateEKartonCommand(DentaCareContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public int Id => 10;

        public string Name => "Create EKarton with Ef";

        public void Execute(EKartonDto request)
        {
            var ekarton = new EKarton
            {
                Date = request.Date,
                Price = request.Price
            };

            _context.EKarton.Add(ekarton);
            _context.SaveChanges();
        }
    }
}
