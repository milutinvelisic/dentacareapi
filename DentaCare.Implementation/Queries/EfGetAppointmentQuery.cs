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
    public class EfGetAppointmentQuery : IGetAppointmentQuery
    {
        private readonly DentaCareContext _context;

        public EfGetAppointmentQuery(DentaCareContext context)
        {
            this._context = context;
        }
        public int Id => 36;

        public string Name => "Appointments Search";

        public PagedResponse<AppointmentDto> Execute(AppointmentSearch search)
        {
            var query = _context.Appointments.AsQueryable();

            if (!string.IsNullOrEmpty(search.FirstNameLastName) || !string.IsNullOrWhiteSpace(search.FirstNameLastName))
            {
                query = query.Where(x => x.FirstNameLastName.ToLower().Contains(search.FirstNameLastName.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<AppointmentDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new AppointmentDto
                {
                    Id = x.Id,
                    FirstNameLastName = x.FirstNameLastName
                }).ToList()
            };

            return response;
        }
    }
}
