using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DentaCare.Application.DataTransfer;
using DentaCare.Domain;

namespace DentaCare.Api.Core
{
    public class EKartonProfile : Profile
    {
        public EKartonProfile()
        {
            CreateMap<EKarton, EKartonDto>();
        }
    }
}
