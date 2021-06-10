using System;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Data
{
    public interface IUnityOfWork : IDisposable
    {
        void BeginTransaction();
        Task Commit();
        void Rollback();
    }
}
