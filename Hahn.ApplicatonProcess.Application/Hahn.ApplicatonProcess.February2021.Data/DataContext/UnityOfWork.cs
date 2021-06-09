using System;

namespace Hahn.ApplicatonProcess.February2021.Data
{
    public sealed class UnityOfWork : IUnityOfWork
    {
        //TODO create dbcontext

        public UnityOfWork()
        {
            
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
