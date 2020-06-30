using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.DataTransfer;
using DentaCare.Application.Searches;

namespace DentaCare.Application.Queries
{
    public interface IGetServiceTypeQuery : IQuery<ServiceTypeSearch, PagedResponse<ServiceTypeDto>>
    {
    }
}
