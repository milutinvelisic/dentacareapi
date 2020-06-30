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
    public class EfGetTeethQuery : IGetTeethQuery
    {
        private readonly DentaCareContext _context;

        public EfGetTeethQuery(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 43;

        public string Name => "Teeth Search";

        public PagedResponse<TeethDto> Execute(TeethSearch search)
        {
            var query = _context.Teeth.AsQueryable();

            if (!string.IsNullOrEmpty(search.ToothNumber.ToString()) || !string.IsNullOrWhiteSpace(search.ToothNumber.ToString()))
            {
                query = query.Where(x => x.ToothNumber.ToString().ToLower().Contains(search.ToothNumber.ToString().ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<TeethDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new TeethDto
                {
                    Id = x.Id,
                    ToothNumber = x.ToothNumber
                }).ToList()
            };

            return response;
        }
    }
}
