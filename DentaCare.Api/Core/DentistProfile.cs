using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DentaCare.Application.DataTransfer;
using DentaCare.Domain;

namespace DentaCare.Api.Core
{
    public class DentistProfile : Profile
    {
        public DentistProfile()
        {
            CreateMap<Dentist, DentistDto>();
        }
    }
}
