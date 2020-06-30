using DentaCare.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.Queries;

namespace DentaCare.Application.Searches
{
    public class JawSideToothSearch : PagedSearch
    {
        public int JawId { get; set; }

        public virtual JawDto Jaw { get; set; }

        public int JawSideId { get; set; }

        public virtual JawSideDto JawSide { get; set; }

        public int ToothId { get; set; }

        public virtual TeethDto Tooth { get; set; }
    }
}
