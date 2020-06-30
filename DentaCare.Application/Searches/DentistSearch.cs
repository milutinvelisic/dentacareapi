using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Queries;

namespace DentaCare.Application.Searches
{
    public class DentistSearch : PagedSearch
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
