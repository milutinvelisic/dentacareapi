using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using DentaCare.Application;
using DentaCare.Domain;
using DentaCareDataAccess;

namespace DentaCare.Implementation.Logging
{
    public class DatabaseUseCaseLogger : IUseCaseLogger
    {
        private readonly DentaCareContext _context;

        public DatabaseUseCaseLogger(DentaCareContext context) => _context = context;

        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            _context.UseCaseLog.Add(new UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonSerializer.Serialize(useCaseData),
                Date = DateTime.UtcNow,
                UseCaseName = useCase.Name
            });

            _context.SaveChanges();
        }
    }
}
