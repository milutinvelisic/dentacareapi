using DentaCare.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Application.Searches
{
    public class AppointmentSearch : PagedSearch
    {
        public string FirstNameLastName { get; set; }

        public string Email { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public string Phone { get; set; }
    }
}
