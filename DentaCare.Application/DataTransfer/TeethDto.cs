using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Application.DataTransfer
{
    public class TeethDto
    {
        public int Id { get; set; }

        public int ToothNumber { get; set; }

        public ICollection<JawJawSideToothDto> JawJawSideTeeth { get; set; } = new HashSet<JawJawSideToothDto>();
    }
}
