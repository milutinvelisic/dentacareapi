using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCare.Application
{
    public interface ICommand<TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }

    public interface IQuery<TSearch, TResult> : IUseCase
    {
        TResult Execute(TSearch search);
    }

    public interface IUseCase
    {
        int Id { get; }
        string Name { get; }
    }
}
