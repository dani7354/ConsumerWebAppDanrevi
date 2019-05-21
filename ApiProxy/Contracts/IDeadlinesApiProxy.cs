using System;
using Models.Deadline;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ApiProxy.Contracts
{
    public interface IDeadlinesApiProxy
    {
        Task<IList<T>> GetAllDeadlinesAsync<T>();
        Task<T> FindDeadline<T>(int id);

    }
}
