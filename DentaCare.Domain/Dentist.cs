using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Domain
{
    public class Dentist : EntityBase
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
