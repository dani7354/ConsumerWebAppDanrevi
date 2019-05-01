using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using Domain;

namespace ApiProxy.Contracts
{
    public interface IArticleApiProxy : IApiProxy
    {
        new void Find<T>(int id) where T : ArticleBase;
        new IList<T> All<T>() where T : ArticleBase;
        new void Create<T>(T article) where T : ArticleBase;

    }
}
