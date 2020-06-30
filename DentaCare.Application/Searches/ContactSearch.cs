﻿using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Queries;

namespace DentaCare.Application.Searches
{
    public class ContactSearch : PagedSearch
    {
        public string Address { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }
    }
}
