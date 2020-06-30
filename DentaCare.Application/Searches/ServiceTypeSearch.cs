using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Queries;

namespace DentaCare.Application.Searches
{
    public class ServiceTypeSearch : PagedSearch
    {
        public string ServiceName { get; set; }

        public string ServiceDescription { get; set; }

        public decimal ServicePrice { get; set; }
    }
}
