using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using DentaCare.Application;

namespace DentaCare.Implementation.Logging
{
    public class ConsoleUseCaseLogger : IUseCaseLogger
    {
        public void Log(IUseCase useCase, IApplicationActor actor, object data)
        {
            Console.WriteLine($"{DateTime.Now}: {actor.Identity} is trying to execute {useCase.Name} using data: {JsonSerializer.Serialize(data)}");
        }
    }
}
