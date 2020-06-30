using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentaCare.Application.DataTransfer;
using DentaCare.Application.Queries;
using DentaCare.Application.Searches;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Queries
{
    public class EfGetServiceTypeQuery : IGetServiceTypeQuery
    {
        private readonly DentaCareContext _context;

        public EfGetServiceTypeQuery(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 42;

        public string Name => "ServiceTypes Search";

        public PagedResponse<ServiceTypeDto> Execute(ServiceTypeSearch search)
        {
            var query = _context.ServiceTypes.AsQueryable();

            if (!string.IsNullOrEmpty(search.ServiceName) || !string.IsNullOrWhiteSpace(search.ServiceName))
            {
                query = query.Where(x => x.ServiceName.ToLower().Contains(search.ServiceName.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<ServiceTypeDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new ServiceTypeDto
                {
                    Id = x.Id,
                    ServiceName = x.ServiceName
                }).ToList()
            };

            return response;
        }
    }
}
