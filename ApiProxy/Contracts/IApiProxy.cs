using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProxy.Contracts
{
    public interface IApiProxy<T>
    {
        IList<T> All<T2>();
        T Find<T2>(int id);
        void Create<T2>(T article);
        void Delete(int id);

    }

}
