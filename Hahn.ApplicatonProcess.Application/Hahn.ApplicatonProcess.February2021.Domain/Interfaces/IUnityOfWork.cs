using System;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Data
{
    public interface IUnityOfWork : IDisposable
    {
        Task<bool> Commit();
        Task Rollback();
    }
}
