using DentaCare.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Application.DataTransfer
{
    public class EKartonDto : EntityBaseDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public int ServiceTypeId { get; set; }

        public ServiceTypeDto ServiceTypes { get; set; }

        public int JawJawSideToothId { get; set; }

        public JawJawSideToothDto JawJawSideTooth { get; set; }

        public virtual ICollection<UserDto> Users { get; set; } = new HashSet<UserDto>();
    }
}
