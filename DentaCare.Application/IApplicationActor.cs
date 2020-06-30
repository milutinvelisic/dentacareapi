﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Application
{
    public interface IApplicationActor
    {
        int Id { get; }
        string Identity { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
