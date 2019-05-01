using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProxy.Contracts
{
    public interface IApiProxy
    {
        IList<T> All<T>();
        T Find<T>(int id);
        void Create<T>(T article);
        void Delete(int id);

    }

}
