using DentaCare.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Queries;

namespace DentaCare.Application.Searches
{
    public class EKartonSearch : PagedSearch
    {
        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public int ServiceTypeId { get; set; }

        public ServiceTypeDto ServiceTypes { get; set; }

        public int JawJawSideToothId { get; set; }

        public JawJawSideToothDto JawJawSideTooth { get; set; }
    }
}
