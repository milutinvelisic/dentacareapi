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
    public class EfGetContactQuery : IGetContactQuery
    {
        private readonly DentaCareContext _context;

        public EfGetContactQuery(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 37;

        public string Name => "Contact Search";

        public PagedResponse<ContactDto> Execute(ContactSearch search)
        {
            var query = _context.Contact.AsQueryable();

            if (!string.IsNullOrEmpty(search.Address) || !string.IsNullOrWhiteSpace(search.Address))
            {
                query = query.Where(x => x.Address.ToLower().Contains(search.Address.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<ContactDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new ContactDto
                {
                    Id = x.Id,
                    Address = x.Address
                }).ToList()
            };

            return response;
        }
    }
}
