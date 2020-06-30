using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentaCare.Application;

namespace DentaCare.Api.Core
{
    public class FakeApiActor : IApplicationActor
    {
        public int Id => 1;
        public string Identity => "Test Api User";

        public IEnumerable<int> AllowedUseCases => new List<int>{1};
    }

    public class AdminApiActor : IApplicationActor
    {
        public int Id => 2;

        public string Identity => "Fake Admin";

        public IEnumerable<int> AllowedUseCases => new List<int>{1,2,3,4,5,6,7};
    }
}
