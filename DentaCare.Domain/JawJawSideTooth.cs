using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Domain
{
    public class JawJawSideTooth : EntityBase
    {

        public int Id { get; set; }

        public int JawId { get; set; }

        public virtual Jaw Jaw { get; set; }

        public int JawSideId { get; set; }

        public virtual JawSide JawSide { get; set; }

        public int ToothId { get; set; }

        public virtual Teeth Tooth { get; set; }

        public virtual ICollection<EKarton> EKarton { get; set; } = new HashSet<EKarton>();

    }
}
