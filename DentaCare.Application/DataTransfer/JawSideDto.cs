using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Application.DataTransfer
{
    public class JawSideDto
    {
        public int Id { get; set; }

        public string JawSideName { get; set; }

        public ICollection<JawJawSideToothDto> JawJawSideTeeth { get; set; } = new HashSet<JawJawSideToothDto>();
    }
}
