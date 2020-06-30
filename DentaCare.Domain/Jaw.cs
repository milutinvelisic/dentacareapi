using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Domain
{
    public class Jaw : EntityBase
    {

        public int Id { get; set; }

        public string JawName { get; set; }

        public ICollection<JawJawSideTooth> JawJawSideTeeth { get; set; } = new HashSet<JawJawSideTooth>();

    }
}
