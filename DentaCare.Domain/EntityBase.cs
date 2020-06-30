using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Domain
{
    public class EntityBase
    {

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive{ get; set; }

    }
}
