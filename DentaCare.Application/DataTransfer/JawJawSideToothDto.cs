using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Application.DataTransfer
{
    public class JawJawSideToothDto
    {
        public int Id { get; set; }

        public int JawId { get; set; }

        public virtual JawDto Jaw { get; set; }

        public int JawSideId { get; set; }

        public virtual JawSideDto JawSide { get; set; }

        public int ToothId { get; set; }

        public virtual TeethDto Tooth { get; set; }

        public virtual ICollection<EKartonDto> EKarton { get; set; } = new HashSet<EKartonDto>();
    }
}
