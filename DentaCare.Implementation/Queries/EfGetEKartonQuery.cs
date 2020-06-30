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
    public class EfGetEKartonQuery : IGetEKartonQuery
    {
        private readonly DentaCareContext _context;

        public EfGetEKartonQuery(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 39;

        public string Name => "EKarton Search";

        public PagedResponse<EKartonDto> Execute(EKartonSearch search)
        {
            var query = _context.EKarton.AsQueryable();

            if (!string.IsNullOrEmpty(search.Price.ToString()) || !string.IsNullOrWhiteSpace(search.Price.ToString()))
            {
                query = query.Where(x => x.Price.ToString().ToLower().Contains(search.Price.ToString().ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<EKartonDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new EKartonDto
                {
                    Id = x.Id,
                    Price = x.Price
                }).ToList()
            };

            return response;
        }
    }
}
