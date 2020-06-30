using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Queries;

namespace DentaCare.Application.Searches
{
    public class JawSideSearch : PagedSearch
    {
        public string JawSideName { get; set; }
    }
}
