using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Application.DataTransfer
{
    public class UserDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int RoleId { get; set; }

        public int EKartonId { get; set; }

        public virtual RoleDto Role { get; set; }

        public virtual EKartonDto Ekarton { get; set; }
    }
}
