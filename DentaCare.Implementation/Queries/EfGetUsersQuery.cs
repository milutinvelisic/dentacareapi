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
    public class EfGetUsersQuery : IGetUserQuery
    {
        private readonly DentaCareContext _context;

        public EfGetUsersQuery(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 35;

        public string Name => "Users Search";

        public PagedResponse<UserDto> Execute(UserSearch search)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(search.FirstName) || !string.IsNullOrWhiteSpace(search.FirstName))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.FirstName.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<UserDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new UserDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName
                }).ToList()
            };

            return response;
        }
    }
}
