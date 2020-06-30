using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentaCare.Application;

namespace DentaCare.Api.Core
{
    public class AnonymousActor : IApplicationActor
    {
        public int Id => 0;

        public string Identity => "Anonymus";

        public IEnumerable<int> AllowedUseCases => new List<int> { 5 };
    }
}
