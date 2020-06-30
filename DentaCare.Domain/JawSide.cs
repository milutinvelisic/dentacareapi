using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Domain
{
    public class JawSide : EntityBase
    {

        public int Id { get; set; }

        public string JawSideName { get; set; }

        public ICollection<JawJawSideTooth> JawJawSideTeeth { get; set; } = new HashSet<JawJawSideTooth>();

    }
}
