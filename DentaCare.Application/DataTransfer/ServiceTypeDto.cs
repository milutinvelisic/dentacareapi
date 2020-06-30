using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Application.DataTransfer
{
    public class ServiceTypeDto
    {
        public int Id { get; set; }

        public string ServiceName { get; set; }

        public string ServiceDescription { get; set; }

        public decimal ServicePrice { get; set; }

        public virtual ICollection<AppointmentDto> Appointments { get; set; } = new HashSet<AppointmentDto>();

        public virtual ICollection<EKartonDto> EKarton { get; set; } = new HashSet<EKartonDto>();
    }
}
