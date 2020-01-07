namespace BackEnd.Infra.Data.Interfaces
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
