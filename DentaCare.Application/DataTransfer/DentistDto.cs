﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Application.DataTransfer
{
    public class DentistDto : EntityBaseDto
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
