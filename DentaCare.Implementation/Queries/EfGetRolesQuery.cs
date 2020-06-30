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
    public class EfGetRolesQuery : IGetRoleQuery
    {
        private readonly DentaCareContext _context;

        public EfGetRolesQuery(DentaCareContext context)
        {
            this._context = context;
        }

        public int Id => 4;

        public string Name => "Roles Search";

        public PagedResponse<RoleDto> Execute(RoleSearch search)
        {
            var query = _context.Roles.AsQueryable();

            if (!string.IsNullOrEmpty(search.RoleName) || !string.IsNullOrWhiteSpace(search.RoleName))
            {
                query = query.Where(x => x.RoleName.ToLower().Contains(search.RoleName.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<RoleDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new RoleDto
                {
                    Id = x.Id,
                    RoleName = x.RoleName
                }).ToList()
            };

            return response;
        }
    }
}
