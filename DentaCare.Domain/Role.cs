using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Domain
{
    public class Role : EntityBase
    {
        public int Id { get; set; }

        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
