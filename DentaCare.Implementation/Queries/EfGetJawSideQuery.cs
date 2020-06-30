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
    public class EfGetJawSideQuery : IGetJawSideQuery
    {
        private readonly DentaCareContext _context;

        public EfGetJawSideQuery(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 41;

        public string Name => "JawSides Search";

        public PagedResponse<JawSideDto> Execute(JawSideSearch search)
        {
            var query = _context.JawSides.AsQueryable();

            if (!string.IsNullOrEmpty(search.JawSideName) || !string.IsNullOrWhiteSpace(search.JawSideName))
            {
                query = query.Where(x => x.JawSideName.ToLower().Contains(search.JawSideName.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<JawSideDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new JawSideDto
                {
                    Id = x.Id,
                    JawSideName = x.JawSideName
                }).ToList()
            };

            return response;
        }
    }
}
