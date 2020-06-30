using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Application.DataTransfer
{
    public class RoleDto
    {
        public int Id { get; set; }

        public string RoleName { get; set; }    

        //public virtual ICollection<UserDto> Users { get; set; } = new HashSet<UserDto>();
    }
}
