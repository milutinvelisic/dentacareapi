using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Domain
{
    public class Appointment : EntityBase
    {

        public int Id { get; set; }

        public string FirstNameLastName { get; set; }

        public string Email { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public string Phone { get; set; }

        public virtual ServiceType ServiceTypes { get; set; }

        public int ServiceTypeId { get; set; }

    }
}
