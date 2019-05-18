using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProxy.Contracts
{
    public interface ITagApiProxy
    {
        Task<IList<T>> GetAllTagsAsync<T>();
    }
}
