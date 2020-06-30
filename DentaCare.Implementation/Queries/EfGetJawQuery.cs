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
    public class EfGetJawQuery : IGetJawQuery
    {
        private readonly DentaCareContext _context;

        public EfGetJawQuery(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 40;

        public string Name => "Jaws Search";

        public PagedResponse<JawDto> Execute(JawSearch search)
        {
            var query = _context.Jaws.AsQueryable();

            if (!string.IsNullOrEmpty(search.JawName) || !string.IsNullOrWhiteSpace(search.JawName))
            {
                query = query.Where(x => x.JawName.ToLower().Contains(search.JawName.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<JawDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new JawDto
                {
                    Id = x.Id,
                    JawName = x.JawName
                }).ToList()
            };

            return response;
        }
    }
}
