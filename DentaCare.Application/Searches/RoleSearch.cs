using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Queries;

namespace DentaCare.Application.Searches
{
    public class RoleSearch : PagedSearch
    {
        public string RoleName { get; set; }
    }
}
