using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Domain
{
    public class EKarton : EntityBase
    {

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public int ServiceTypeId { get; set; }

        public ServiceType ServiceTypes { get; set; }

        public int JawJawSideToothId { get; set; }

        public JawJawSideTooth JawJawSideTooth { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

    }
}
