using System;

namespace Hahn.ApplicatonProcess.February2021.Data
{
    public interface IUnityOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
