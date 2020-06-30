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
    public class EfGetDentistQuery : IGetDentistQuery
    {
        private readonly DentaCareContext _context;

        public EfGetDentistQuery(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 38;

        public string Name => "Dentists Search";

        public PagedResponse<DentistDto> Execute(DentistSearch search)
        {
            var query = _context.Dentists.AsQueryable();

            if (!string.IsNullOrEmpty(search.FirstName) || !string.IsNullOrWhiteSpace(search.FirstName))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.FirstName.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<DentistDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new DentistDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName
                }).ToList()
            };

            return response;
        }
    }
}
