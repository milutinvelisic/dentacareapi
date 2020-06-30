using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Domain
{
    public class Contact : EntityBase
    {

        public int Id { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

    }
}
