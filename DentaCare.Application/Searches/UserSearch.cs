using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Queries;

namespace DentaCare.Application.Searches
{
    public class UserSearch : PagedSearch
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int RoleId { get; set; }

        public int EKartonId { get; set; }
    }
}
